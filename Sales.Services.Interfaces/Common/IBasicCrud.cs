using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Services.Interfaces.Common
{
    public interface IBasicCrud<CreateDTO,UpdateDTO,RegisterDTO>
    {
        IEnumerable<RegisterDTO> ListAll();
        RegisterDTO Register(CreateDTO request);
        RegisterDTO Update(UpdateDTO request);
        IEnumerable<RegisterDTO> QueryPage(Page request);
        void Delete(int id);
    }
}
