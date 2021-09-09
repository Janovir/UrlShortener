using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUriValidatorService
    {
        bool UriIsValid(string uri);
    }
}
