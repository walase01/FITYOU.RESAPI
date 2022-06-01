using FITYOU.DATA.Contexts;
using FITYOU.DATA.Models;
using FITYOU.Services.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITYOU.Services.user
{
    public class User : IUser
    {
        private readonly FitYouDB2Context context;
        public User(FitYouDB2Context _context)
        {
            this.context = _context;
        }

        public async Task<FitYouResponse> AddUser(Administrator user)
        {
            var result = new FitYouResponse<string>();

            try
            {
                var response = await this.context.Administrators.FindAsync(user.Id);

                if (response != null)
                {
                    result.Errors.Add(new Error(CodeError.NotFound, "El usuario ya ha sido registrado"));
                    return result;
                }
                else
                {
                    await this.context.Administrators.AddAsync(user);
                    var save = await this.context.SaveChangesAsync();

                    if(save < 0)
                    {
                        result.Errors.Add(new Error(CodeError.NotFound, "A ocurrido un error al guardar el usuario"));
                    }
                    else
                    {
                        result.Value = "Usuario agregado correctamente";
                    }
                }
                
                return result;

            }
            catch (Exception ex)
            {
                result.Errors.Add(new Error(CodeError.BadRequest, ex.Message));
                return result;
            }
        }

        public async Task<FitYouResponse> DeleteUser(int id)
        {
            var result = new FitYouResponse<string>();

            try
            {
                var response = await this.context.Administrators.FindAsync(id);

                if (response == null)
                {
                    result.Errors.Add(new Error(CodeError.NotFound, "No se ha encontrado el usuarios"));
                    return result;
                }
                else
                {
                    this.context.Administrators.Remove(response);
                    var save = await this.context.SaveChangesAsync();

                    if (save < 0)
                    {
                        result.Errors.Add(new Error(CodeError.NotFound, "A ocurrido un error al eliminar el usuario"));
                    }
                    else
                    {
                        result.Value = "Usuario eliminado correctamente";
                    }
                }

                return result;

            }
            catch (Exception ex)
            {
                result.Errors.Add(new Error(CodeError.BadRequest, ex.Message));
                return result;
            }
        }

        public async Task<FitYouResponse> GetAllUser()
        {
            var result = new FitYouResponse<List<Administrator>>();

            try
            {
                var response = await this.context.Administrators.ToListAsync();

                if(response == null)
                {
                    result.Errors.Add(new Error(CodeError.NotFound, "No se encontraron Usuarios"));
                    return result;
                }
                result.Value = response;

                return result;

            }catch(Exception ex)
            {
                result.Errors.Add(new Error(CodeError.BadRequest, ex.Message));
                return result;
            }
        }
        public async Task<FitYouResponse> GetUser(int id)
        {
            var result = new FitYouResponse<Administrator>();

            try
            {
                var resposnse = await this.context.Administrators.FindAsync(id);

                if (resposnse == null)
                {
                    result.Errors.Add(new Error(CodeError.NotFound, "No se encontro usuario"));
                    return result;
                }

                result.Value = resposnse;

                return result;

            }
            catch (Exception ex)
            {
                result.Errors.Add(new Error(CodeError.BadRequest, ex.Message));
                return result;
            }
        }
        public async Task<FitYouResponse> UpdateUser(int id, Administrator user)
        {
            var result = new FitYouResponse<Administrator>();

            try
            {

                if(id != user.Id)
                {
                    result.Errors.Add(new Error(CodeError.BadRequest, "Los parametros ingresador son diferentes"));
                }
                else
                {
                    this.context.Entry(user).State = EntityState.Modified;
                    var response = await this.context.SaveChangesAsync();

                    if (response < 0)
                    {
                        result.Errors.Add(new Error(CodeError.NotFound, "No fue posible modificar el usuario"));
                    }
                    else
                    {
                        result.Value = await this.context.Administrators.FindAsync(id);
                    }
                }

                return result;

            }
            catch (Exception ex)
            {
                result.Errors.Add(new Error(CodeError.BadRequest, ex.Message));
                return result;
            }
        }
        public async Task<FitYouResponse> ValidateUser(string user, string password)
        {
            var result = new FitYouResponse<Administrator>();

            try
            {
                var response = await this.context.Administrators.Where(x => x.Username == user && x.Password == password).FirstOrDefaultAsync();

                if (response == null)
                {
                    result.Errors.Add(new Error(CodeError.NotFound, "Uusario no encontrado"));
                    return result;
                }
                result.Value = response;

                return result;

            }
            catch (Exception ex)
            {
                result.Errors.Add(new Error(CodeError.BadRequest, ex.Message));
                return result;
            }
        }

    }
}
