using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities
{
    public class ListActivity
    {
        
        public class Query : IRequest<List<Activity>>
        {
            
        }

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context
                                    .Activities
                                    .Select(x => new Activity()
                                    {
                                        Id = x.Id,
                                        Title = x.Title,
                                        Date = x.Date,
                                        Description = x.Description,
                                        Category = x.Category,
                                        City = x.City,
                                        Venue = x.Venue
                                    }).ToListAsync();

            }
        }
    }
}