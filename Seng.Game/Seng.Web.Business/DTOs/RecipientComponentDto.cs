using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Seng.Web.Business.DTOs
{
    public class RecipientComponentDto : ComponentBaseDto
    {
        public string Address { get; set; }

        public string Description { get; set; }

        public string ContentHeader { get; set; }

        public IEnumerable<NewEmailParagraphComponentDto> FirstParagraphs { get; set; } = new List<NewEmailParagraphComponentDto>();

        public string ContentFooter { get; set; }

        public IEnumerable<ButtonDto> Buttons { get; set; } = new List<ButtonDto>();

        public bool Active { get; set; }

    }
}
