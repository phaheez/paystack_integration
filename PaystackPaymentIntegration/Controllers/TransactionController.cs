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
                //ViewBag.Results = results;

                return View(results);
            } 
        }

        // New Payment View
        public ActionResult make_payment()
        {
            return View();
        }

        //Make New Payment
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

                            Response.Redirect(initializeResponse.Data.AuthorizationUrl);
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
                }
            }
            return View(model);
        }

        //View Payment Details
        public ActionResult payment_details(string tranxRef)
        {
            if (tranxRef == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var result = new PaymentUOW().Transaction.VerifyTransaction(tranxRef);

            ViewBag.Details = result;

            return View(result);
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

        //Save to DB With Ajax from UI
        public JsonResult SavePayment(string email, int amount, string reference)
        {
            using (var uow = new PaymentUOW())
            {
                var newRecord = new transaction_record
                {
                    email = email,
                    amount = amount,
                    reference = reference,
                    created_date = DateTime.UtcNow
                };

                uow.Transaction.Add(newRecord);
                int response = uow.Complete();

                if (response > 0)
                {
                    return Json(new { error = false, result = "success" }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { error = true, result = "error" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
