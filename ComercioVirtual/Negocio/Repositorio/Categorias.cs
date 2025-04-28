using System.Text;
using Negocio.ClientHttp;
using Negocio.Helper;
using Newtonsoft.Json;

namespace Negocio.Repositorio
{
    internal class Categorias()
    {
        public static async Task<List<Shared.Entities.Categorias>> Get()
        {
            try
            {
                var response = await ApiServer
                    .ObtenerClientHttp()
                    .GetAsync(
                        ApiServer.ObtenerUrlEndPoint(
                            ApplicationConfiguration.GetSetting(
                                "ApiServer:EndPoints:Categorias:ObtenerTodo"
                            )
                        )
                    );

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<List<Shared.Entities.Categorias>>(
                        result
                    );

                    return returnModel!;
                }
                else
                {
                    throw new Exception($"Failed to retrieve items returned {response.StatusCode}");
                }
            }
            catch
            {
                throw new Exception($"Failed to connect to api server");
            }
        }

        public static async Task<Shared.Entities.Categorias?> Get(int id)
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting(
                    "ApiServer:EndPoints:Categorias:ObtenerPorId"
                );
                path = string.Format(path, id);

                var response = await ApiServer
                    .ObtenerClientHttp()
                    .GetAsync(ApiServer.ObtenerUrlEndPoint(path));

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<Shared.Entities.Categorias>(result);

                    return returnModel!;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw new Exception($"Failed to retrieve items returned {response.StatusCode}");
                }
            }
            catch
            {
                throw new Exception($"Failed to connect to api server");
            }
        }

        public static async Task<List<Shared.Entities.Categorias>?> Get(string nombre)
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting(
                    "ApiServer:EndPoints:Categorias:ObtenerPorNombre"
                );
                path = string.Format(path, nombre);

                var response = await ApiServer
                    .ObtenerClientHttp()
                    .GetAsync(ApiServer.ObtenerUrlEndPoint(path));

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<List<Shared.Entities.Categorias>>(
                        result
                    );

                    return returnModel!;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw new Exception($"Failed to retrieve item returned {response.StatusCode}");
                }
            }
            catch
            {
                throw new Exception($"Failed to connect to api server");
            }
        }

        public static async Task<Shared.Entities.Categorias> Create(Shared.Dtos.Categorias.CrearDTO Categorias)
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting("ApiServer:EndPoints:Categorias:Crear");
                var stringContent = new StringContent(
                    JsonConvert.SerializeObject(Categorias),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await ApiServer
                    .ObtenerClientHttp()
                    .PostAsync(ApiServer.ObtenerUrlEndPoint(path), stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<Shared.Entities.Categorias>(result);

                    return returnModel!;
                }
                else
                {
                    throw new Exception($"Failed to create items returned {response.StatusCode}");
                }
            }
            catch
            {
                throw new Exception($"Failed to connect to api server");
            }
        }

        public static async Task Delete(int id)
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting(
                    "ApiServer:EndPoints:Categorias:Borrar"
                );
                path = string.Format(path, id);

                var response = await ApiServer
                    .ObtenerClientHttp()
                    .DeleteAsync(ApiServer.ObtenerUrlEndPoint(path));

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception($"Failed to delete items returned {response.StatusCode}");
                }
            }
            catch
            {
                throw new Exception($"Failed to connect to api server");
            }
        }

        public static async Task<Shared.Entities.Categorias> Update(
            int id,
            Shared.Dtos.Categorias.ModificarDTO Categorias
        )
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting(
                    "ApiServer:EndPoints:Categorias:Actualizar"
                );
                path = string.Format(path, id);
                var stringContent = new StringContent(
                    JsonConvert.SerializeObject(Categorias),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await ApiServer
                    .ObtenerClientHttp()
                    .PutAsync(ApiServer.ObtenerUrlEndPoint(path), stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<Shared.Entities.Categorias>(result);

                    return returnModel!;
                }
                else
                {
                    throw new Exception($"Failed to update items returned {response.StatusCode}");
                }
            }
            catch
            {
                throw new Exception($"Failed to connect to api server");
            }
        }
    }
}
