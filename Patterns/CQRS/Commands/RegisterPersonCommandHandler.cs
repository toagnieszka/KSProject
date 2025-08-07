using KSProject.Patterns.ChainOfResponsibility;
using KSProject.Patterns.Repository;
using KSProject.Patterns.Stategy;

namespace KSProject.Patterns.CQRS.Commands
{
    public class RegisterPersonCommandHandler : ICommandHandler<RegisterPersonCommand>
    {
        private readonly IRepository repository;
        private readonly StrategySelector selector;
        private readonly ValidationChainFactory validationChainFactory;

        public RegisterPersonCommandHandler(IRepository repository, StrategySelector selector, ValidationChainFactory validationChainFactory) 
        {
            this.repository = repository;
            this.selector = selector;
            this.validationChainFactory = validationChainFactory;
        }

        public async Task Handle(RegisterPersonCommand command)
        {
			var strategy = selector.Select(command)
			 ?? throw new InvalidOperationException("No valid strategy found for the command.");

			var validationChain = validationChainFactory.Create(strategy);
			await validationChain.Handle(command);

			var builder = new PersonBuilder()
            .SetId(command.Id)
            .SetName(command.Name)
            .SetSurname(command.Surname)
            .SetPesel(command.Pesel)
            .SetAge(command.Age)
            .SetInsuranceNumber(command.InsuranceNumber)
            .SetMedlicalLicense(command.MedicalLicense)
            .SetSpecialization(command.Specialization)
            .UseStrategy(strategy);

            var person = builder.Build();
            await repository.Save(person);
        }
    }
}
