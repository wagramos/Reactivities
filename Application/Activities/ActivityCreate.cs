using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class ActivityCreate
    {
        public class Command : IRequest
        {
            public Activity Activity { get; init; }

            public Command(Activity activity) => this.Activity = activity;
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _dataContext;

            public Handler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _dataContext.Activities.Add(request.Activity);
                await _dataContext.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}