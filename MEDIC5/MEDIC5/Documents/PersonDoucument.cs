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

                    page.Header().Height(100).Background(Colors.Grey.Lighten1);
                    page.Content().Background(Colors.Grey.Lighten3);
                    page.Footer().Height(50).Background(Colors.Grey.Lighten1);
                });
        }


    }
}
