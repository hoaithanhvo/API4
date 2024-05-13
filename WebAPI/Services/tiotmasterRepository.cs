using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Services
    {
    public class tiotmasterRepository : ITiotmasterRepository
        {
        private readonly NIDEC_IOTContext _context;
        public static int PAGESIZE {get;set;} =15;

        public tiotmasterRepository(NIDEC_IOTContext context)
            {
            _context = context;
            }

        public ITiotmasterView Create(ITiotmasterView Item)
            {
            var item = new TIotMoldMaster
                {
                CavQty = Item.CavQty,
                StackQty = Item.StackQty,
                Id = Item.Id,
                MachineCd = Item.MachineCd,
                MachineStatus = Item.MachineStatus,
                MaintenanceQty = Item.MaintenanceQty,
                MaintenanceShot = Item.MaintenanceShot,
                MaterialType = Item.MaterialType,
                MaterialUsage = Item.MaterialUsage,
                MoldName = Item.MoldName,
                MoldNo = Item.MoldNo,
                MoldSerial = Item.MoldSerial,
                ReycleRatio = Item.ReycleRatio,
                ScrapQty = Item.ScrapQty,
                ScrapShot = Item.ScrapShot,
                };
            _context.Add(item);
            _context.SaveChanges();
            return new ITiotmasterView
                {
                CavQty = Item.CavQty,
                StackQty = Item.StackQty,
                Id = Item.Id,
                MachineCd = Item.MachineCd,
                MachineStatus = Item.MachineStatus,
                MaintenanceQty = Item.MaintenanceQty,
                MaintenanceShot = Item.MaintenanceShot,
                MaterialType = Item.MaterialType,
                MaterialUsage = Item.MaterialUsage,
                MoldName = Item.MoldName,
                MoldNo = Item.MoldNo,
                MoldSerial = Item.MoldSerial,
                ReycleRatio = Item.ReycleRatio,
                ScrapQty = Item.ScrapQty,
                ScrapShot = Item.ScrapShot,
                };
            }

        public void DeleteById(int id)
            {
            var checkItem = _context.TIotMoldMasters.SingleOrDefault(hh => hh.Id == id);
            if (checkItem != null)
                {
                _context.Remove(checkItem);
                _context.SaveChanges(true);
                }
            }

        public ITiotmasterView GetById(int id)
            {
            var checkItem = _context.TIotMoldMasters.SingleOrDefault(hh => hh.Id == id);
            if (checkItem == null)
                {
                return null;
                }
            return new ITiotmaster
                {
                CavQty = checkItem.CavQty,
                StackQty = checkItem.StackQty,
                MachineCd = checkItem.MachineCd,
                MachineStatus = checkItem.MachineStatus,
                MaintenanceQty = checkItem.MaintenanceQty,
                MaintenanceShot = checkItem.MaintenanceShot,
                MaterialType = checkItem.MaterialType,
                MaterialUsage = checkItem.MaterialUsage,
                MoldName = checkItem.MoldName,
                MoldNo = checkItem.MoldNo,
                MoldSerial = checkItem.MoldSerial,
                ReycleRatio = checkItem.ReycleRatio,
                ScrapQty = checkItem.ScrapQty,
                ScrapShot = checkItem.ScrapShot,
                };

            }

        public List<ITiotmasterView> GetList(string modelSerial, double? from, double? to,string sortBy,int page)
            {
            var list = _context.TIotMoldMasters.AsQueryable();
            #region Filtering
            if (!string.IsNullOrEmpty(modelSerial))
                {
                list = list.Where(hh => hh.MoldSerial == modelSerial);
                }

            if(from.HasValue) {

                list = list.Where(hh => hh.ScrapShot >= Convert.ToDecimal(from));
                }
            if (to.HasValue)
                {

                list = list.Where(hh => hh.ScrapShot < Convert.ToDecimal(to));
                }
            #endregion


            #region sort

            // Mặc định tên tăng dần

            list = list.OrderBy(hh => hh.ScrapQty);
            if(!string.IsNullOrEmpty(sortBy))
                {

                switch(sortBy)
                    {
                    case "tenhh_desc": list = list.OrderByDescending(hh => hh.ScrapQty);break;
                    case "gia_asc": list = list.OrderByDescending(hh => hh.ScrapShot); break;
                    case "gia_desc": list = list.OrderBy(hh => hh.ScrapShot); break;
                    }
                }
            #endregion

            #region Pageing
            
            list = list.Skip((page - 1) * PAGESIZE).Take(PAGESIZE);
            #endregion
            var result = list.Select(hh => new ITiotmasterView
                {
                CavQty = hh.CavQty,
                StackQty = hh.StackQty,
                MachineCd = hh.MachineCd,
                MachineStatus = hh.MachineStatus,
                MaintenanceQty = hh.MaintenanceQty,
                MaintenanceShot = hh.MaintenanceShot,
                MaterialType = hh.MaterialType,
                MaterialUsage = hh.MaterialUsage,
                MoldName = hh.MoldName,
                MoldNo = hh.MoldNo,
                MoldSerial = hh.MoldSerial,
                ReycleRatio = hh.ReycleRatio,
                ScrapQty = hh.ScrapQty,
                ScrapShot = hh.ScrapShot,
                });
            return result.ToList();
            }

        public void Update(ITiotmaster Item, int id)
            {
            var checkItem = _context.TIotMoldMasters.SingleOrDefault(hh => hh.Id == id);
            checkItem.CavQty = Item.CavQty;
            checkItem.StackQty = Item.StackQty;
            checkItem.MachineCd = Item.MachineCd;
            checkItem.MachineStatus = Item.MachineStatus;
            checkItem.MaintenanceQty = Item.MaintenanceQty;
            checkItem.MaintenanceShot = Item.MaintenanceShot;
            checkItem.MaterialType = Item.MaterialType;
            checkItem.MaterialUsage = Item.MaterialUsage;
            checkItem.MoldName = Item.MoldName;
            checkItem.MoldNo = Item.MoldNo;
            checkItem.MoldSerial = Item.MoldSerial;
            checkItem.ReycleRatio = Item.ReycleRatio;
            checkItem.ScrapQty = Item.ScrapQty;
            checkItem.ScrapShot = Item.ScrapShot;
            _context.SaveChanges();
            }
        }
    }
