using System.Text;
using Negocio.ClientHttp;
using Negocio.Helper;
using Newtonsoft.Json;

// cambiar cosas de persona a tipoDocumento

namespace Negocio.Repositorio
{
    internal class TipoDocumento()
    {
        public static async Task<List<Shared.Entities.TipoDocumento>> Get()
        {
            try
            {
                var response = await ApiServer
                    .ObtenerClientHttp()
                    .GetAsync(
                        ApiServer.ObtenerUrlEndPoint(
                            ApplicationConfiguration.GetSetting(
                                "ApiServer:EndPoints:TipoDocumento:ObtenerTodo"
                            )
                        )
                    );

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<List<Shared.Entities.TipoDocumento>>(
                        result
                    );

                    return returnModel!;
                }
                else
                {
                    throw new Exception($"Failed to retrieve items returned {response.StatusCode}");
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Failed to connect to api server");
            }
        }

        public static async Task<Shared.Entities.TipoDocumento?> Get(int id)
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting(
                    "ApiServer:EndPoints:TipoDocumento:ObtenerPorId"
                );
                path = string.Format(path, id);

                var response = await ApiServer
                    .ObtenerClientHttp()
                    .GetAsync(ApiServer.ObtenerUrlEndPoint(path));

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<Shared.Entities.TipoDocumento>(result);

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

        public static async Task<List<Shared.Entities.TipoDocumento>?> Get(string nombre)
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting(
                    "ApiServer:EndPoints:TipoDocumento:ObtenerPorNombre"
                );
                path = string.Format(path, nombre);

                var response = await ApiServer
                    .ObtenerClientHttp()
                    .GetAsync(ApiServer.ObtenerUrlEndPoint(path));

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<List<Shared.Entities.TipoDocumento>>(
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

        public static async Task<Shared.Entities.TipoDocumento> Create(Shared.Dtos.TipoDocumento.CrearDTOTipoDocumento tipoDocumento)
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting("ApiServer:EndPoints:TipoDocumento:Crear");
                var stringContent = new StringContent(
                    JsonConvert.SerializeObject(tipoDocumento),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await ApiServer
                    .ObtenerClientHttp()
                    .PostAsync(ApiServer.ObtenerUrlEndPoint(path), stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<Shared.Entities.TipoDocumento>(result);

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
                    "ApiServer:EndPoints:TipoDocumento:Borrar"
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

        public static async Task<Shared.Entities.TipoDocumento> Update(
            int id,
            Shared.Dtos.TipoDocumento.ModificarDTOTipoDocumento tipoDocumento
        )
        {
            try
            {
                string path = ApplicationConfiguration.GetSetting(
                    "ApiServer:EndPoints:TipoDocumento:Actualizar"
                );
                path = string.Format(path, id);
                var stringContent = new StringContent(
                    JsonConvert.SerializeObject(tipoDocumento),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await ApiServer
                    .ObtenerClientHttp()
                    .PutAsync(ApiServer.ObtenerUrlEndPoint(path), stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<Shared.Entities.TipoDocumento>(result);

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
