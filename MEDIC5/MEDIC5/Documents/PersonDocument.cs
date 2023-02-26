using MEDIC5.Models;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Helpers;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;


namespace MEDIC5.Documents
{
    public class PersonDocument : IDocument
    {
        public Person Model { get; }

        public PersonDocument (Person person)
        {
            Model = person;
        }



        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container
            .Page(page =>
            {
                page.Margin(50);

                page.Header().Element(ComposeHeader);

                page.Content().Element(ComposeContent);

                page.Footer().Element(ComposeFooter);
            });
        }

        public void ComposeHeader(IContainer container)
        {
            container.Background(Colors.Grey.Lighten3).Padding(10).
                Row(row =>
                {
                    row.Spacing(5);

                    row.RelativeItem()
                        .Width(100)
                        .Height(100)
                        .Image("Logo.png");

                    row.RelativeItem().AlignCenter().Column(column =>
                    {
                        column.Spacing(5);
                        column.Item().Text("Mohawk College").FontSize(14);
                        column.Item().Text("Fake address 123").FontSize(12);
                        column.Item().Text("Fake phone number and email address").FontSize(12);
                    });
                });
        }

        public void ComposeFooter(IContainer container)
        {
            container.Background(Colors.Grey.Lighten3).Padding(10).Column(column =>
            {
                column.Spacing(5);
                column.Item().Text("Copyright " + DateTime.Now.Year).FontSize(12);
                column.Item().AlignRight().Text(x =>
                {
                    x.CurrentPageNumber().FontSize(12);
                    x.Span(" / ").FontSize(12);
                    x.TotalPages().FontSize(12);
                });
            });
        }


        // Think of this as the content section that holds other components to the 
        // container
        void ComposeContent(IContainer container)
        {
            container.PaddingVertical(1).Column(column =>
            {
                column.Item().Element(ComposePerson);

                column.Item().AlignMiddle().AlignCenter().Element(ComposeSignature);
            });
        }

        // Think of this as one container
        void ComposePerson(IContainer container)
        {
            container
               .PaddingVertical(5)
               .Background(Colors.Grey.Lighten3)
               .AlignCenter()
               .Row(row =>
               {
                   row.Spacing(5);
                   row.RelativeItem().Column(column =>
                   {
                       column.Item().Text("Name: " + Model.Name).FontSize(14);
                       column.Item().Text("Email: " + Model.Email).FontSize(14);
                       column.Item().Text("Phone Number: " + Model.PhoneNumber).FontSize(14);
                       column.Item().Text("Address: " + Model.Address).FontSize(14);
                   });

                   row.RelativeItem().Column(column =>
                   {
                       column.Item().Text("City: " + Model.City).FontSize(14);
                       column.Item().Text("Province: " + Model.Province).FontSize(14);
                       column.Item().Text("Zip Code: " + Model.ZipCode).FontSize(14);
                       column.Item().Text("Country: " + Model.Country).FontSize(14);
                       column.Item().Text("Date of Birth: " + Model.DateOfBirth).FontSize(14);
                   });
               });
        }



        void ComposeSignature(IContainer container)
        {
            container
            .PaddingVertical(5)
            .AlignMiddle()
            
            .Column(col =>
            {

                string signature = Model.Signature.Replace("data:image/png;base64,", "");
                byte[] imageBytes = Convert.FromBase64String(signature);
                using (var ms = new MemoryStream(imageBytes))
                {
                    using (var image = Image.Load(ms))
                    {
                        var pngEncoder = new PngEncoder();
                        var outputStream = new MemoryStream();
                        image.Save(outputStream, pngEncoder);
                        var imageData = outputStream.ToArray();

                        col.Item()
                            .Background(Colors.White)
                            .BorderColor(Colors.Black)
                            .Border(1)
                            .MaxWidth(400)
                            .MaxWidth(300)
                            .Image(imageData);
                    }
                }


            });
            
        }


    }
}
