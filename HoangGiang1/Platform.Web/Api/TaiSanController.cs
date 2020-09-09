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
    [RoutePrefix("api/taisan")]
    [Authorize]
    public class TaiSanController : ApiControllerBase
    {
        ITaiSanService _taiSanService;

        public TaiSanController(ILoiService loiService, ITaiSanService coSoViecService) : base(loiService)
        {
            this._taiSanService = coSoViecService;
        }
        [Route("createExcel")]
        [HttpPost]
        // [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, IEnumerable<TaiSanViewModel> taiSanViewModels)
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
                    foreach (var item in taiSanViewModels)
                    {
                        var newThongBao = new TaiSan();
                        newThongBao.UpdateTaiSan(item);

                        _taiSanService.Add(newThongBao);
                        _taiSanService.Save();
                    }


                    //var responseData = Mapper.Map<DangKy_TamThoi, DangKy_TamThoiViewModel>(newDangKy_TamThoi);
                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        // [AllowAnonymous]
        public HttpResponseMessage CreateVienChuc(HttpRequestMessage request, TaiSanViewModel taiSanViewModel)
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

                    var newPhongHoc = new TaiSan();
                    newPhongHoc.UpdateTaiSan(taiSanViewModel);
                    newPhongHoc.NgayNhapLieu =DateTime.Now;

                    _taiSanService.Add(newPhongHoc);
                    _taiSanService.Save();




                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }



        public HttpResponseMessage Create(HttpRequestMessage request, TaiSan taiSan)
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
                    _taiSanService.Add(taiSan);
                    _taiSanService.Commit();
                    response = request.CreateResponse(HttpStatusCode.Created, taiSan);
                }
                return response;
            });

        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {


            var listCategory = _taiSanService.GetAll();
            var a = listCategory.OrderBy(x => x.MaTaiSan);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, a);


                return response;
            });
        }
        [Route("getThongkeTaiSan")]
        public HttpResponseMessage getThongkeTaiSan(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listCategory = _taiSanService.getThongkeTaiSan();
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);
                return response;
            });
        }
         [Route("getThongkeNguoiQuanLyTS")]
        public HttpResponseMessage getThongkeNguoiQuanLyTS(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listCategory = _taiSanService.getThongkeNguoiQuanLyTS();
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);
                return response;
            });
        }



         [Route("getnguoinhap")]
        public HttpResponseMessage getnguoinhap(HttpRequestMessage request,string msnv)
        {
            return CreateHttpResponse(request, () =>
            {
                var listCategory = _taiSanService.getnguoinhap(msnv);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);
                return response;
            });
        }




         [Route("ChucNangLocTaiSanTheoMaCoSo")]
         [HttpGet]
        public HttpResponseMessage ChucNangLocTaiSanTheoMaCoSo(HttpRequestMessage request,string MaCoSo)
        {
            return CreateHttpResponse(request, () =>
            {
                var listCategory = _taiSanService.ChucNangLocTaiSanTheoMaCoSo(MaCoSo);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);
                return response;
            });
        }
        [Route("ChucNangLocTaiSanTheoKieuTaiSan")]
         [HttpGet]
        public HttpResponseMessage ChucNangLocTaiSanTheoKieuTaiSan(HttpRequestMessage request,string Model)
        {
            return CreateHttpResponse(request, () =>
            {
                var listCategory = _taiSanService.ChucNangLocTaiSanTheoKieuTaiSan(Model);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);
                return response;
            });
        }



        //[Route("update")]
        //[HttpPut]
        //[AllowAnonymous]
        //public HttpResponseMessage update(HttpRequestMessage request, CoSoViewModel coSoViewModel)
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

        //            var vienchucDb = _taiSanService.getID(Convert.ToInt32(coSoViewModel.MaCoSo));

        //            vienchucDb.UpdateHoanThanhCongViec(CoSoViewModel);
        //            _taiSanService.Update(vienchucDb);
        //            _taiSanService.Commit();

        //            response = request.CreateResponse(HttpStatusCode.OK);

        //        }
        //        return response;
        //    });
        //}



        //[Route("GetHoanThanhCongViec")]
        //public HttpResponseMessage GetHoanThanhCongViec(HttpRequestMessage request, string msnv)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        var model = _taiSanService.GetHoanThanhCongViec(msnv);
        //        var responseData = Mapper.Map<IEnumerable<HoanThanhCongViec>, IEnumerable<HoanThanhCongViec>>(model);
        //        var response = request.CreateResponse(HttpStatusCode.OK, responseData);
        //        return response;
        //    });
        //}

        public HttpResponseMessage Post(HttpRequestMessage request, TaiSan taiSan)
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
                    _taiSanService.Add(taiSan);
                    _taiSanService.Commit();

                    response = request.CreateResponse(HttpStatusCode.Created);

                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, TaiSan taiSan)
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
                    _taiSanService.Update(taiSan);
                    _taiSanService.Commit();

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
                    _taiSanService.delete(id);
                    _taiSanService.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}