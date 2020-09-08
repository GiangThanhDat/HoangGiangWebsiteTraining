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
    [RoutePrefix("api/phieuchi")]
    [Authorize]
    public class PhieuChiController : ApiControllerBase
    {
        IPhieuChiService _phieuChiService;

        public PhieuChiController(ILoiService loiService, IPhieuChiService phieuChiService) : base(loiService)
        {
            this._phieuChiService = phieuChiService;
        }
        //[Route("createExcel")]
        //[HttpPost]
        //// [AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<PhieuChiViewModel> phieuChiVM)
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
        //            foreach (var item in phieuChiVM)
        //            {
        //                var newThongBao = new PhieuChi();
        //                newThongBao.UpdatePhieuChi(item);

        //                _phieuChiService.Add(newThongBao);
        //                _phieuChiService.Save();
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
        //public HttpResponseMessage update(HttpRequestMessage request, PhieuChiViewModel phieuChiViewModel)

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

        //            var vienchucDb = _phieuChiService.getID(Convert.ToInt32(phieuChiViewModel.ID));

        //            vienchucDb.UpdatePhieuChi(phieuChiViewModel);
        //            _phieuChiService.Update(vienchucDb);
        //            _phieuChiService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}






        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, PhieuChiViewModel khachHang)
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
                    var newThongBao = new PhieuChi();
                    newThongBao.UpdatePhieuChi(khachHang);

                    _phieuChiService.Add(newThongBao);
                    _phieuChiService.Save();
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


                var listCategory = _phieuChiService.GetAll();
                //  var responseData = Mapper.Map<IEnumerable<PhieuChi>,IEnumerable<PhieuChiViewModel>>(listCategory);
                var b = listCategory.OrderBy(x => x.MaPhieuChi.Length + x.MaPhieuChi);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, b);


                return response;
            });
        }

        [Route("getPhieuChi")]
        public HttpResponseMessage getPhieuChi(HttpRequestMessage request, DateTime ngaydau, DateTime ngaycuoi)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _phieuChiService.getPhieuChi(ngaydau, ngaycuoi);


                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        [Route("xemPhieuChi")]
        [HttpGet]
        public HttpResponseMessage xemPhieuChi(HttpRequestMessage request, string MaPC)
        {
            return CreateHttpResponse(request, () =>
            {


                var listCategory = _phieuChiService.xemPhieuChi(MaPC);


                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }


        public HttpResponseMessage Post(HttpRequestMessage request, PhieuChi phieuChi)
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
                    _phieuChiService.Add(phieuChi);
                    _phieuChiService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, PhieuChi phieuChi)
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
                    _phieuChiService.Update(phieuChi);
                    _phieuChiService.Commit();

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
                    _phieuChiService.delete(id);
                    _phieuChiService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}
