using MEDIC5.Models;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Helpers;

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
            container.Background(Colors.Grey.Lighten3).Padding(10).Row(row =>
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


        void ComposeContent(IContainer container)
        {
            container
                .PaddingVertical(40)
                .Background(Colors.Grey.Lighten3)
                .AlignCenter()
                .Column(column =>
                {
                    column.Spacing(5);
                    column.Item().Text("Name: " + Model.Name).FontSize(14);
                    column.Item().Text("Email: " + Model.Email).FontSize(14);
                    column.Item().Text("Phone Number: " + Model.PhoneNumber).FontSize(14);
                    column.Item().Text("Address: " + Model.Address).FontSize(14);
                    column.Item().Text("City: " + Model.City).FontSize(14);
                    column.Item().Text("Province: " + Model.Province).FontSize(14);
                    column.Item().Text("Zip Code: " + Model.ZipCode).FontSize(14);
                    column.Item().Text("Country: " + Model.Country).FontSize(14);
                    column.Item().Text("Date of Birth: " + Model.DateOfBirth).FontSize(14);
                    column.Item().Text("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer vel libero nec velit sagittis commodo non eu magna. Integer eget lectus id lacus rutrum semper in at libero. Praesent pellentesque laoreet aliquam. Quisque non libero quam. Duis auctor purus eget augue commodo, in tincidunt enim hendrerit. Sed eget pharetra ligula, at eleifend nisl.").FontSize(14);
                    column.Item().Text("Aenean eget vestibulum velit. Sed in diam vel nulla sollicitudin aliquet vel et eros. Aenean vulputate, massa a faucibus tincidunt, nibh odio accumsan sem, eget pulvinar enim tellus in odio. Sed fringilla, ante vitae fringilla blandit, libero libero pellentesque orci, id congue risus lacus euismod lorem. Sed porttitor purus quis libero tempor, id efficitur orci commodo.").FontSize(14);
                    column.Item().Text("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer vel libero nec velit sagittis commodo non eu magna. Integer eget lectus id lacus rutrum semper in at libero. Praesent pellentesque laoreet aliquam. Quisque non libero quam. Duis auctor purus eget augue commodo, in tincidunt enim hendrerit. Sed eget pharetra ligula, at eleifend nisl.").FontSize(14);
                    column.Item().Text("Aenean eget vestibulum velit. Sed in diam vel nulla sollicitudin aliquet vel et eros. Aenean vulputate, massa a faucibus tincidunt, nibh odio accumsan sem, eget pulvinar enim tellus in odio. Sed fringilla, ante vitae fringilla blandit, libero libero pellentesque orci, id congue risus lacus euismod lorem. Sed porttitor purus quis libero tempor, id efficitur orci commodo.").FontSize(14);
                    column.Item().Text("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer vel libero nec velit sagittis commodo non eu magna. Integer eget lectus id lacus rutrum semper in at libero. Praesent pellentesque laoreet aliquam. Quisque non libero quam. Duis auctor purus eget augue commodo, in tincidunt enim hendrerit. Sed eget pharetra ligula, at eleifend nisl.").FontSize(14);
                    column.Item().Text("Aenean eget vestibulum velit. Sed in diam vel nulla sollicitudin aliquet vel et eros. Aenean vulputate, massa a faucibus tincidunt, nibh odio accumsan sem, eget pulvinar enim tellus in odio. Sed fringilla, ante vitae fringilla blandit, libero libero pellentesque orci, id congue risus lacus euismod lorem. Sed porttitor purus quis libero tempor, id efficitur orci commodo.").FontSize(14);
                    column.Item().Text("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer vel libero nec velit sagittis commodo non eu magna. Integer eget lectus id lacus rutrum semper in at libero. Praesent pellentesque laoreet aliquam. Quisque non libero quam. Duis auctor purus eget augue commodo, in tincidunt enim hendrerit. Sed eget pharetra ligula, at eleifend nisl.").FontSize(14);
                    column.Item().Text("Aenean eget vestibulum velit. Sed in diam vel nulla sollicitudin aliquet vel et eros. Aenean vulputate, massa a faucibus tincidunt, nibh odio accumsan sem, eget pulvinar enim tellus in odio. Sed fringilla, ante vitae fringilla blandit, libero libero pellentesque orci, id congue risus lacus euismod lorem. Sed porttitor purus quis libero tempor, id efficitur orci commodo.").FontSize(14);
                });
        }


    }
}
