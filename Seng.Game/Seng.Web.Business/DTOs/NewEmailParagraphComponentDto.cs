using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Web.Business.DTOs
{
    public class NewEmailParagraphComponentDto : ComponentBaseDto
    {
        public string Text { get; set; }

        public int RecipientComponentId { get; set; }

        public IEnumerable<NewEmailParagraphComponentDto> ChildrenParagraphs { get; set; }
    }
}
