using AutoMapper;
using Newtonsoft.Json.Linq;
using Platform.Model;
using Platform.Service;
using Platform.Web.infratructure.core;
using Platform.Web.infratructure.extensions;
using Platform.Web.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Platform.Web.Infrastructure.Core;

namespace Platform.Web.Api
{
    [RoutePrefix("api/chitiettralaihangban")]
    [Authorize]
    public class ChiTietTraLaiHangBanController : ApiControllerBase
    {
        IChiTietTraLaiHangBanService _chiTietTraLaiHangBanService;

        public ChiTietTraLaiHangBanController(ILoiService loiService, IChiTietTraLaiHangBanService chiTietTraLaiHangBanService) : base(loiService)
        {
            this._chiTietTraLaiHangBanService = chiTietTraLaiHangBanService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietTraLaiHangBanViewModel> chiTietTraLaiHangBanVM)
        //{


        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        if (!ModelState.IsValid)
        //        {
        //            response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {
        //            foreach (var item in chiTietTraLaiHangBanVM)
        //            {
        //                var newThongBao = new ChiTietTraLaiHangBan();
        //                newThongBao.UpdateChiTietTraLaiHangBan(item);

        //                _chiTietTraLaiHangBanService.Add(newThongBao);
        //                _chiTietTraLaiHangBanService.Save();
        //            }


        //            //var responseData = Mapper.Map<DangKy_TamThoi, DangKy_TamThoiViewModel>(newDangKy_TamThoi);
        //            response = request.CreateResponse(HttpStatusCode.OK);
        //        }

        //        return response;
        //    });
        //}


        //[Route("update")]
        //[HttpPut]
        //[AllowAnonymous]
        //public HttpResponseMessage update(HttpRequestMessage request, ChiTietTraLaiHangBanViewModel chiTietTraLaiHangBanViewModel)

        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        if (!ModelState.IsValid)
        //        {
        //            request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {

        //            var vienchucDb = _chiTietTraLaiHangBanService.getID(Convert.ToInt32(chiTietTraLaiHangBanViewModel.ID));

        //            vienchucDb.UpdateChiTietTraLaiHangBan(chiTietTraLaiHangBanViewModel);
        //            _chiTietTraLaiHangBanService.Update(vienchucDb);
        //            _chiTietTraLaiHangBanService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}






        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<ChiTietTraLaiHangBanViewModel> chiTietTraLaiHangBanVM)
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
                    foreach (var item in chiTietTraLaiHangBanVM)
                    {
                        var newThongBao = new ChiTietTraLaiHangBan();
                        newThongBao.UpdateChiTietTraLaiHangBan(item);

                        _chiTietTraLaiHangBanService.Add(newThongBao);
                        _chiTietTraLaiHangBanService.Save();
                    }
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


                var listCategory = _chiTietTraLaiHangBanService.GetAll();
             
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        [Route("getbyid")]
        public HttpResponseMessage getbyid(HttpRequestMessage request,string id)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _chiTietTraLaiHangBanService.getbyid(id);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        [Route("getchitiettralaihangban")]
        public HttpResponseMessage getchitiettralaihangban(HttpRequestMessage request,string MaTraLaiHangBan)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _chiTietTraLaiHangBanService.getchitiettralaihangban(MaTraLaiHangBan);
                //  var responseData = Mapper.Map<IEnumerable<ChiTietTraLaiHangBan>,IEnumerable<ChiTietTraLaiHangBanViewModel>>(listCategory);
               // var b = listCategory.OrderBy(x => x.MaChiTietTraLaiHangBan.Length + x.MaChiTietTraLaiHangBan);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        

        public HttpResponseMessage Post(HttpRequestMessage request, ChiTietTraLaiHangBan chiTietTraLaiHangBan)
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
                    _chiTietTraLaiHangBanService.Add(chiTietTraLaiHangBan);
                    _chiTietTraLaiHangBanService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, ChiTietTraLaiHangBan chiTietTraLaiHangBan)
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
                    _chiTietTraLaiHangBanService.Update(chiTietTraLaiHangBan);
                    _chiTietTraLaiHangBanService.Commit();

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
                    _chiTietTraLaiHangBanService.delete(id);
                    _chiTietTraLaiHangBanService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}
