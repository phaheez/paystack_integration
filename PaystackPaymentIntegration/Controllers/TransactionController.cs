using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PaystackPaymentIntegration.Models.DataModel;
using PaystackPaymentIntegration.Models.Entities;
using PaystackPaymentIntegration.Models.DTOs.Writable;
using PaystackPaymentIntegration.Models;

namespace PaystackPaymentIntegration.Controllers
{
    public class TransactionController : Controller
    {
        public async Task<ActionResult> Index()
        {
            using (var uow = new PaymentUOW())
            {
                var results = await uow.Transaction.GetAllTransactions();
                ViewBag.Results = results;

                return View();
            }
                
        }

        // GET: Transaction/make_payment
        public ActionResult make_payment()
        {
            return View();
        }

        // POST: Transaction/make_payment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> make_payment([Bind(Include = "email,amount")] TransactionDTOW model)
        {
            using (var uow = new PaymentUOW())
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        var errorMessage = string.Empty;

                        //Initialize Transaction
                        var initializeResponse = uow.Transaction.InitializeTransaction(model.email, model.amount);

                        if (initializeResponse.Status)
                        {
                            Response.Redirect(initializeResponse.Data.AuthorizationUrl);

                            //Verify Transaction
                            var verifyResponse = uow.Transaction.VerifyTransaction(initializeResponse.Data.Reference);
                            if (verifyResponse.Status)
                            {
                                //save records to database
                                var newRecord = new transaction_record
                                {
                                    email = model.email,
                                    amount = model.amount,
                                    reference = initializeResponse.Data.Reference,
                                    created_date = DateTime.UtcNow
                                };

                                uow.Transaction.Add(newRecord);
                                await uow.CompleteAsync();

                                //return RedirectToAction("fetch_transaction");
                            }
                            else
                            {
                                errorMessage = verifyResponse.Message;
                            }
                        }
                        else
                        {
                            errorMessage = initializeResponse.Message;
                        }

                        ViewBag.ErrorMessage = errorMessage;
                        return View("PaymentError");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    //ModelState.AddModelError("", "Unable to save transactions. Try again, and if the problem persists see your system administrator.");
                }
            }
            return View(model);
        }

        //Calling With Ajax from UI
        public JsonResult InitializePayment(TransactionDTOW model)
        {
            using (var uow = new PaymentUOW())
            {
                var response = uow.Transaction.InitializeTransaction(model.email, model.amount);

                if (response.Status == true)
                {
                    return Json(new { error = false, result = response }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { error = true, result = response }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
