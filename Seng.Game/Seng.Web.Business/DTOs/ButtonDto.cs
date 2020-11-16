using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seng.Web.Business.DTOs
{
    public class ButtonDto : ComponentBaseDto
    {
        public string ButtonText { get; set; }
        public IEnumerable<SendEmailToPlayerActionDto> SendEmailToPlayerActions { get; set; } = new List<SendEmailToPlayerActionDto>();
        public IEnumerable<SwitchIntermissionFrameActionDto> SwitchIntermissionFramesActions { get; set; } = new List<SwitchIntermissionFrameActionDto>();
        public IEnumerable<UpdateMainVisibleModuleActionDto> UpdateMainVisibleModuleActions { get; set; } = new List<UpdateMainVisibleModuleActionDto>();
        public IEnumerable<AddRecipientToNewEmailActionDto> AddRecipientToNewEmailActions { get; set; } = new List<AddRecipientToNewEmailActionDto>();
    }
}
