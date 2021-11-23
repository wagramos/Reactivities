using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities;
public class ActivityList
{
    public class Query : IRequest<IReadOnlyList<Activity>> { }

    public class Handler : IRequestHandler<Query, IReadOnlyList<Activity>>
    {
        private readonly DataContext _context;
        public Handler(DataContext context)
        {
            _context = context;

        }
        public async Task<IReadOnlyList<Activity>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _context.Activities.ToListAsync();
        }
    }
}