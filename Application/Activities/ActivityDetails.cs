using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class ActivityDetails
    {
        public class Query : IRequest<Activity>
        {
            public Guid Id { get; init; }

            public Query(Guid id)
            {
                Id = id;
            }
        }

        public class Handler : IRequestHandler<Query, Activity>
        {
            private readonly DataContext _dataContext;
            public Handler(DataContext dataContext)
            {
                _dataContext = dataContext;

            }
            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _dataContext.Activities.FindAsync(request.Id);
            }
        }
    }
}