using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seng.Web.Business.DTOs
{
    public class QuestionDto : ComponentBaseDto
    {
        public string Text { get; set; }
        public IEnumerable<OptionDto> Options { get; set; } = new List<OptionDto>();
    }
}
