using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CafeneaSite.Data;
using CafeneaSite.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.EntityFrameworkCore;
using QRCoder;
using Newtonsoft.Json;
using System.Drawing;
using Microsoft.Extensions.Hosting;
using SendGrid.Helpers.Mail;
using SendGrid;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace CafeneaSite.Pages.Cafele
{
    public class CreateModel : CafeaTipuriToppingPageModel
    {
        private readonly CafeneaSite.Data.CafeneaSiteContext _context;

        public IConfiguration Configuration { get; }

        public CreateModel(CafeneaSite.Data.CafeneaSiteContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public IActionResult OnGet()
        {
            // POPULARE VIEWDATA - TIP CAFEA
            var listaTipCafea = _context.TipCafea.Select(x => new
            {
                x.ID,
                x.Tip,
                x.Imagine
            });
            ViewData["TipCafeaID"] = new SelectList(listaTipCafea, "ID", "Tip", "Imagine");

            // POPULARE VIEWDATA - TIP BOABE
            var listaTipBoabe = _context.TipBoabe.Select(x => new
            {
                x.ID,
                x.DenumireBoabe
            });
            ViewData["TipBoabeID"] = new SelectList(listaTipBoabe, "ID", "DenumireBoabe");

            // POPULARE VIEWDATA - TIP LAPTE
            var listaTipLapte = _context.TipLapte.Select(x => new
            {
                x.ID,
                x.DenumireLapte
            });
            ViewData["TipLapteID"] = new SelectList(listaTipLapte, "ID", "DenumireLapte");

            // POPULARE VIEWDATA - TIP AROMA
            var listaTipAroma = _context.TipAroma.Select(x => new
            {
                x.ID,
                x.DenumireAroma
            });
            ViewData["TipAromaID"] = new SelectList(listaTipAroma, "ID", "DenumireAroma");

            // POPULARE VIEWDATA - TIP TOPPING
            var listaTipTopping = _context.TipTopping.Select(x => new
            {
                x.ID,
                x.DenumireTopping
            });
            ViewData["TipToppingID"] = new SelectList(listaTipTopping, "ID", "DenumireTopping");

            var cafea = new Cafea();
            cafea.CafeaTipuriTopping = new List<CafeaTipuriTopping>();
            PopulateToppingAtribuitCafeleiData(_context, cafea);


            return Page();
        }

        [BindProperty]
        public Cafea Cafea { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        //static async Task SendEmailAsync(string recipientEmail, byte[] qrCodeImage)
        //{
        //    var apiKey = "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";
        //    var client = new SendGridClient(apiKey);
        //    var from = new EmailAddress("adela.maria1920@gmail.com", "Kovacs Adela");
        //    var to = new EmailAddress("adela.maria1920@gmail.com", "Kovacs Adela");
        //    var subject = "QR Code Image";
        //    var htmlContent = "Here's your QR code image:";
        //    var plainTextContent = "Here's your QR code image:";
        //    //var attachment = new Attachment
        //    //{
        //    //    Content = Convert.ToBase64String(qrCodeImage),
        //    //    Filename = "qr-code.png",
        //    //    Type = "image/png",
        //    //    Disposition = "inline",
        //    //    ContentId = "qr-code"
        //    //};
        //    var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        //    //msg.AddAttachment(attachment);
        //    var response = await client.SendEmailAsync(msg);
        //}
        public async Task<IActionResult> OnPostAsync(string[] selectedToppings)
        {
            var newCafea = new Cafea();
            if (selectedToppings != null)
            {
                newCafea.CafeaTipuriTopping = new List<CafeaTipuriTopping>();
                foreach (var cat in selectedToppings)
                {
                    var catToAdd = new CafeaTipuriTopping
                    {
                        TipToppingID = int.Parse(cat)
                    };
                    newCafea.CafeaTipuriTopping.Add(catToAdd);
                }
            }

            // Generare QR code
            var qrData = new
            {
                Cafea.DenumireCafea,
                Cafea.TipCafeaID,
                Cafea.TipBoabeID,
                Cafea.TipLapteID,
                Cafea.TipAromaID,
                Cafea.Pret
            };
            string qrPayload = JsonConvert.SerializeObject(qrData);
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrPayload, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new BitmapByteQRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(2);

            //Ca sa salvez imaginea pe serverul meu
            string qrCodePath = "C:\\Users\\Adela-Maria KOVACS\\Desktop\\LICENȚĂ\\Aplicatie Web  Cafenea - SEARCH STRING\\QR_CODE" + Cafea.ID + ".png";
            System.IO.File.WriteAllBytes(qrCodePath, qrCodeImage);

            //// Send the email to the user
            //var user = await _context.Membru.FirstOrDefaultAsync(u => u.Email == Membru.Nume);
            //await SendEmailAsync(user.Email, qrCodeImage);

            // Save the path to the QR code image in the Cafea object
            Cafea.QrCodeURL = qrCodePath;

            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("adela.maria1920@gmail.com", "Kovacs Adela");
            var to = new EmailAddress("adela.maria1920@gmail.com", "Kovacs Adela");
            var subject = "QR Code Image";
            var htmlContent = "Here's your QR code image:";
            var plainTextContent = "Here's your QR code image:";
            //var attachment = new Attachment
            //{
            //    Content = Convert.ToBase64String(qrCodeImage),
            //    Filename = "qr-code.png",
            //    Type = "image/png",
            //    Disposition = "inline",
            //    ContentId = "qr-code"
            //};
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            //msg.AddAttachment(attachment);
            var response = await client.SendEmailAsync(msg);




            Cafea.CafeaTipuriTopping = newCafea.CafeaTipuriTopping;
            _context.Cafea.Add(Cafea);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        
        PopulateToppingAtribuitCafeleiData(_context, newCafea);
        return Page();
    }
}
    }
