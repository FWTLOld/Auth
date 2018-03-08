﻿using System.Data.Entity;
using System.Threading.Tasks;
using Auth.FWT.Core.CQRS;
using Auth.FWT.Core.Data;
using Auth.FWT.Core.Extensions;
using Auth.FWT.Events;
using NodaTime;

namespace QueueReceiver.Handlers
{
    public class AllTelegramMessagesFetchedHandler : IEventHandler<AllTelegramMessagesFetched>
    {
        private IClock _clock;
        private IEventDispatcher _eventDispatcher;
        private IUnitOfWork _unitOfWork;

        public AllTelegramMessagesFetchedHandler(IUnitOfWork unitOfWork, IClock clock, IEventDispatcher eventDispatcher)
        {
            _unitOfWork = unitOfWork;
            _clock = clock;
            _eventDispatcher = eventDispatcher;
        }

        public async Task Execute(AllTelegramMessagesFetched @event)
        {
            var job = await _unitOfWork.TelegramJobRepository.Query().FirstOrDefaultAsync(tj => tj.JobId == @event.JobId);
            job.LastStatusUpdateDateUTC = _clock.UtcNow();
            job.Status = Auth.FWT.Core.Enums.Enum.TelegramJobStatus.Processing;

            _unitOfWork.TelegramJobRepository.Update(job);
            await _unitOfWork.SaveChangesAsync();

            await _eventDispatcher.Dispatch(new TelegramJobModified()
            {
                UserId = job.UserId,
                TelegramJobId = job.Id
            });
        }
    }
}