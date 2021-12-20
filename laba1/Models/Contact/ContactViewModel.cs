using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace laba1.Models.Contact
{
    public class ContactViewModel
    {
        public string EmailAddress { get; set; }
        public string Username { get; set; }
    }

    public class ContactViewModelValidator : AbstractValidator<ContactViewModel>
    {
        public ContactViewModelValidator()
        {
            RuleFor(x => x.EmailAddress).NotNull().EmailAddress();
            RuleFor(x => x.Username).MinimumLength(4);
        }
    }
}
