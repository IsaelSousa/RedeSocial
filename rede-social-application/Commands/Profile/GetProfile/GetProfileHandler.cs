﻿using MediatR;
using rede_social_application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rede_social_application.Commands.Profile.GetProfile
{
    public class GetProfileHandler : IRequestHandler<GetProfileRequest, Response<string>>
    {
        public Task<Response<string>> Handle(GetProfileRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
