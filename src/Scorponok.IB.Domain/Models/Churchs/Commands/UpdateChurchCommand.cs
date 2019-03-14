using System;
using Scorponok.IB.Domain.Models.Churchs.Commands.Validators;

namespace Scorponok.IB.Domain.Models.Churchs.Commands
{
    public class UpdateChurchCommand : ChurchCommand
    {
        public override bool IsValid()
        {
            var commandValidator = new UpdateChurchCommandValidator();
            this.ValidationResult = commandValidator.Validate(this);

            return this.ValidationResult.IsValid;
        }

        #region Factory

        public static class Factory
        {
            public static UpdateChurchCommand Create(Guid id, string name, string photo, string email, string cellPhone, string homePhone)
            {
                return new UpdateChurchCommand()
                {
                    Id = id,
                    Name = name,
                    Photo = photo,
                    Email = email,
                    CellPhone = cellPhone,
                    HomePhone = homePhone
                };
            }
        }

        #endregion

    }
}