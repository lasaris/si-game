using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seng.Web.Business.DTOs
{
    public class IntermissionFrameDto : ComponentBaseDto
    {
        public string FrameType { get; set; }
        public string Text { get; set; }
        public IEnumerable<QuestionDto> Questions { get; set; } = new List<QuestionDto>();
        public IEnumerable<ButtonDto> Buttons { get; set; } = new List<ButtonDto>();
    }
}
