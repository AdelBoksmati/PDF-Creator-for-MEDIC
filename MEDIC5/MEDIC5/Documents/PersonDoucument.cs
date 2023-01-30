using MEDIC5.Models;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Helpers;

namespace MEDIC5.Documents
{
    public class PersonDoucument : IDocument
    {
        public Person Model { get; }

        public PersonDoucument (Person person)
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


                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.CurrentPageNumber();
                        x.Span(" / ");
                        x.TotalPages();
                    });
                });
        }

        void ComposeHeader(IContainer container)
        {
            container.Background(Colors.Grey.Lighten3).Padding(10).Column(column =>
            {

                column.Spacing(5);
                column.Item().Text("RCM Health Consultancy Inc.").FontSize(14);
                column.Item().Text("1006 Avenue Road, Suite 100, Toronto, Ontario, M5P 2K8 Canada").FontSize(12);
                column.Item().Text("(647) 350-5500, (416) 961-3322, info@rcmhealth.ca").FontSize(12);
            
                column.Item()
                        .Width(100)
                        .Height(100)
                        .Image("Logo.png");

            });
        }

        void ComposeContent(IContainer container)
        {
            container
                .PaddingVertical(40)
                .Height(250)
                .Background(Colors.Grey.Lighten3)
                .AlignCenter()
                .AlignMiddle()
                .Text("Content").FontSize(16);
        }


    }
}
