using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Web.Business.DTOs
{
    public class AddRecipientToNewEmailActionDto : ActionBaseDto
    {
        public int RecipientComponentId { get; set; }
    }
}
