using System;
using System.Collections.Generic;
using System.Text;

namespace Seng.Game.Business.Commands
{
    public class AddEmailComponentParagraphsCommand : ICommand<bool>
    {
        public int EmailComponentId { get; set; }
        public List<string> ContentParagraphs { get; set; }
    }
}
