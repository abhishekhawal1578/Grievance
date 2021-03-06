﻿using Griveance.Models;
using Griveance.ParamModel;
using Griveance.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.BusinessLayer
{
    public class SaveEmailSetting
    {

        GRContext db = new GRContext();
        public object SaveEmail(ParamEmailSettings PR)
        {
            try
            {

                tbl_emailsettings obj = new tbl_emailsettings();
                
                obj.fromid = PR.fromid;
                obj.host = PR.host;
                obj.port = PR.port;
                obj.password = PR.password;
                obj.Display = 1;
                obj.created_date = DateTime.Now;
                db.tbl_emailsettings.Add(obj);
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Email Settings Saved Successfully." };

            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }


        public object UpdateEmail(ParamEmailSettings PR)
        {
            try
            {


                tbl_emailsettings obj = db.tbl_emailsettings.Where(r => r.emailsettingid == PR.emailsettingid).FirstOrDefault();
               

                obj.fromid = PR.fromid;
                obj.host = PR.host;
                obj.port = PR.port;
                obj.password = PR.password;
                obj.modified_date = DateTime.Now;
             
                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Email Settings Updated Successfully." };

            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
        public object DeleteEmailData(ParamEmailSettings objemail)
        {
            try
            {


                tbl_emailsettings obj = db.tbl_emailsettings.Where(r => r.emailsettingid == objemail.emailsettingid).FirstOrDefault();


                if (obj.Display == 1)
                {
                    obj.Display = 0;
                }
                else
                {
                    obj.Display = 1;
                }

                db.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Email Settings Updated Successfully." };

            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }

    }
} 
