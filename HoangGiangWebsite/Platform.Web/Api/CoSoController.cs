using Platform.Model;
using Platform.Service;
using Platform.Web.infratructure.core;
using Platform.Web.infratructure.extensions;
using Platform.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Platform.Web.Api
{
    [RoutePrefix("api/coso")]
    [Authorize]
    public class CoSoController : ApiControllerBase
    {
        ICoSoService _coSoService;

        public CoSoController(ILoiService loiService, ICoSoService coSoViecService) : base(loiService)
        {
            this._coSoService = coSoViecService;
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, CoSoViewModel CoSoVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var CoSoMoi = new CoSo();
                    CoSoMoi.UpdateCoSo(CoSoVM);

                    _coSoService.Add(CoSoMoi);
                    _coSoService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });

        }

        [Route("createExcel")]
        [HttpPost]
        // [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<CoSoViewModel> coSoVM)
        {


            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    foreach (var item in coSoVM)
                    {
                        var newThongBao = new CoSo();
                        newThongBao.UpdateCoSo(item);

                        _coSoService.Add(newThongBao);
                        _coSoService.Save();
                    }


                    //var responseData = Mapper.Map<DangKy_TamThoi, DangKy_TamThoiViewModel>(newDangKy_TamThoi);
                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }

        [Route("getTenCoSo")]
        public HttpResponseMessage getTenCoSo(HttpRequestMessage request, string msnv)
        {
            return CreateHttpResponse(request, () =>
            {
                var listCategory = _coSoService.getTenCoSo(msnv);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);
                return response;
            });
        }


        [Route("getbyid")]
        public HttpResponseMessage GetById(HttpRequestMessage request, string id)
        {
            return CreateHttpResponse(request, () =>
            {


                var CoSoTheoID = _coSoService.GetByID(id);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, CoSoTheoID);


                return response;
            });
        }


        public HttpResponseMessage Create(HttpRequestMessage request, CoSo coSo)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _coSoService.Add(coSo);
                    _coSoService.Commit();
                    response = request.CreateResponse(HttpStatusCode.Created, coSo);
                }
                return response;
            });

        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _coSoService.GetAll();

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }


        [Route("getbykeyword")]
        public HttpResponseMessage GetByKeyWord(HttpRequestMessage request, string keyword)
        {
            return CreateHttpResponse(request, () =>
            {
                var CoSo = _coSoService.GetByKeyWord(keyword);
                //Console.WriteLine(CoSo);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, CoSo);
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage update(HttpRequestMessage request, CoSoViewModel coSoViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var coSo = _coSoService.GetByID(coSoViewModel.MaCoSo);

                    coSo.UpdateCoSo(coSoViewModel);
                    _coSoService.Update(coSo);
                    _coSoService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }






        public HttpResponseMessage Post(HttpRequestMessage request, CoSo coSo)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _coSoService.Add(coSo);
                    _coSoService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, CoSo coSo)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _coSoService.Update(coSo);
                    _coSoService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }

        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _coSoService.delete(id);
                    _coSoService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}