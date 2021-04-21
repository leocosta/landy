using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Landy.Services.Offer.Core.Events;
using Landy.Services.Offer.Core.Persistence.Repositories;
using Landy.Domain.Repositories;
using FluentValidation;
using AutoMapper;
using Landy.Services.Offer.Core.Dtos;
using Landy.Services.Offer.Core.Commands.Validators;

namespace Landy.Services.Offer.Core.Commands.Handlers
{
    public class OfferCommandHandler :
            IRequestHandler<CreateOfferCommand, CreateOfferResult>
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IOfferRepository offerRepository;
        private readonly CreateOfferCommandValidator commandValidator = new CreateOfferCommandValidator();

        public OfferCommandHandler(
            IMediator mediator,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IOfferRepository offerRepository)
        {
            this.mediator = mediator;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.offerRepository = offerRepository;
        }

        public async Task<CreateOfferResult> Handle(CreateOfferCommand command, CancellationToken cancellationToken)
        {
            commandValidator.ValidateAndThrow(command);

            var offer = mapper.Map<Entities.Offer>(command.Offer);

            await offerRepository.AddOrUpdateAsync(offer);
            await unitOfWork.SaveChangesAsync();

            var offerCreatedEvent = new OfferCreatedEvent
            {
                Offer = mapper.Map<OfferDto>(offer)
            };

            await mediator.Publish(offerCreatedEvent);

            var result = new CreateOfferResult
            {
                Offer = offerCreatedEvent.Offer
            };

            return result;
        }
    }
}