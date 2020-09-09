using AutoMapper;
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
using System.Security.AccessControl;
using System.Web.Http;

namespace Platform.Web.Api
{
    [RoutePrefix("api/QuaTrinhDaoTao")]
    [Authorize]
    public class QuaTrinhDaoTaoController : ApiControllerBase
    {
        IQuaTrinhDaoTaoService _quaTrinhDaoTaoService;

        public QuaTrinhDaoTaoController(ILoiService loiService, IQuaTrinhDaoTaoService quaTrinhDaoTaoService) : base(loiService)
        {
            this._quaTrinhDaoTaoService = quaTrinhDaoTaoService;
        }
        public HttpResponseMessage Create(HttpRequestMessage request, QuaTrinhDaoTao quaTrinhDaoTao)
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
                    _quaTrinhDaoTaoService.Add(quaTrinhDaoTao);
                    _quaTrinhDaoTaoService.Commit();
                    response = request.CreateResponse(HttpStatusCode.Created, quaTrinhDaoTao);
                }
                return response;
            });

        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage update(HttpRequestMessage request, QuaTrinhDaoTaoViewModel quaTrinhDaoTaoVM)
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

                    var vienchucDb = _quaTrinhDaoTaoService.getID(Convert.ToInt32(quaTrinhDaoTaoVM.ID));

                    vienchucDb.UpdateQuaTrinhDaoTao(quaTrinhDaoTaoVM);



                    _quaTrinhDaoTaoService.Update(vienchucDb);
                    _quaTrinhDaoTaoService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }



        [Route("createExcel")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<QuaTrinhDaoTaoViewModel> quaTrinhDaoTaoVm)
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
                    foreach (var item in quaTrinhDaoTaoVm)
                    {
                        var newQuaTrinhDaoTao = new QuaTrinhDaoTao();
                        newQuaTrinhDaoTao.UpdateQuaTrinhDaoTao(item);

                        _quaTrinhDaoTaoService.Add(newQuaTrinhDaoTao);
                        _quaTrinhDaoTaoService.Save();
                    }


                    //var responseData = Mapper.Map<DangKy_TamThoi, DangKy_TamThoiViewModel>(newDangKy_TamThoi);
                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _quaTrinhDaoTaoService.GetAll();

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }

         [Route("GetQuaTrinhDaoTao")]
        public HttpResponseMessage GetQuaTrinhDaoTao(HttpRequestMessage request,string msnv)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _quaTrinhDaoTaoService.GetQuaTrinhDaoTao(msnv);
                var responseData = Mapper.Map<IEnumerable<QuaTrinhDaoTao>, IEnumerable<QuaTrinhDaoTao>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }





        [Route("create")]
        [HttpPost]
        // [AllowAnonymous]
        public HttpResponseMessage Creates(HttpRequestMessage request, IEnumerable<QuaTrinhDaoTaoViewModel> quaTrinhDaoTaoVM)
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
                    var b = "";
                    foreach (var item in quaTrinhDaoTaoVM)
                    {
                        if (item.MaSoNhanVien != null)
                        {
                            b = item.MaSoNhanVien;
                        }
                        var newquaTrinhDaoTao = new QuaTrinhDaoTao();
                        newquaTrinhDaoTao.UpdateQuaTrinhDaoTao(item);
                        newquaTrinhDaoTao.MaSoNhanVien = b;

                        _quaTrinhDaoTaoService.Add(newquaTrinhDaoTao);
                        _quaTrinhDaoTaoService.Save();
                    }



                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }
        [Route("delete")]
        [HttpDelete]
        [HttpGet]
        // [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request, string ID)
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
                    var oldProductCategory = _quaTrinhDaoTaoService.DELETE(int.Parse(ID));
                    _quaTrinhDaoTaoService.Save();

                    var responseData = Mapper.Map<QuaTrinhDaoTao, QuaTrinhDaoTaoViewModel>(oldProductCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
        public HttpResponseMessage Put(HttpRequestMessage request, QuaTrinhDaoTao quaTrinhDaoTao)
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
                    _quaTrinhDaoTaoService.Update(quaTrinhDaoTao);
                    _quaTrinhDaoTaoService.Commit();

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
                    _quaTrinhDaoTaoService.delete(id);
                    _quaTrinhDaoTaoService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }

    }
}