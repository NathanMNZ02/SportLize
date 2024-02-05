using System;
using System.Collections;
using SportLize.Profile.Api.Profile.Business.Abstraction;
using SportLize.Profile.Api.Profile.Repository;
using SportLize.Profile.Api.Profile.Repository.Abstraction;
using SportLize.Profile.Api.Profile.Repository.Enumeration;
using SportLize.Profile.Api.Profile.Repository.Model;
using SportLize.Profile.Api.Profile.Shared;

namespace SportLize.Profile.Api.Profile.Business
{
    public class Business : IBusiness
    {
        private readonly IRepository _repository;

        public Business(IRepository repository)
        {
            _repository = repository;
        }

    }
}

