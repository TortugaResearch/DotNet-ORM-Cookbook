﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace Recipes.Xpo.Entities
{
    public static class SprocHelper
    {
        public static DevExpress.Xpo.DB.SelectedData ExecHR_CountEmployeesByClassification(Session session)
        {
            return session.ExecuteSproc("HR.CountEmployeesByClassification");
        }

        public static System.Collections.Generic.ICollection<CountEmployeesByClassificationResult> ExecHR_CountEmployeesByClassificationIntoObjects(Session session)
        {
            return session.GetObjectsFromSproc<CountEmployeesByClassificationResult>("HR.CountEmployeesByClassification");
        }
        public static XPDataView ExecHR_CountEmployeesByClassificationIntoDataView(Session session)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("HR.CountEmployeesByClassification");
            return new XPDataView(session.Dictionary, session.GetClassInfo(typeof(CountEmployeesByClassificationResult)), sprocData);
        }
        public static void ExecHR_CountEmployeesByClassificationIntoDataView(XPDataView dataView, Session session)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("HR.CountEmployeesByClassification");
            dataView.PopulateProperties(session.GetClassInfo(typeof(CountEmployeesByClassificationResult)));
            dataView.LoadData(sprocData);
        }


        public static DevExpress.Xpo.DB.SelectedData ExecHR_CreateEmployeeClassification(Session session, string EmployeeClassificationName, bool IsExempt, bool IsEmployee)
        {
            return session.ExecuteSproc("HR.CreateEmployeeClassification", new OperandValue(EmployeeClassificationName), new OperandValue(IsExempt), new OperandValue(IsEmployee));
        }
        public static System.Collections.Generic.ICollection<CreateEmployeeClassificationResult> ExecHR_CreateEmployeeClassificationIntoObjects(Session session, string EmployeeClassificationName, bool IsExempt, bool IsEmployee)
        {
            return session.GetObjectsFromSproc<CreateEmployeeClassificationResult>("HR.CreateEmployeeClassification", new OperandValue(EmployeeClassificationName), new OperandValue(IsExempt), new OperandValue(IsEmployee));
        }
        public static XPDataView ExecHR_CreateEmployeeClassificationIntoDataView(Session session, string EmployeeClassificationName, bool IsExempt, bool IsEmployee)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("HR.CreateEmployeeClassification", new OperandValue(EmployeeClassificationName), new OperandValue(IsExempt), new OperandValue(IsEmployee));
            return new XPDataView(session.Dictionary, session.GetClassInfo(typeof(CreateEmployeeClassificationResult)), sprocData);
        }
        public static void ExecHR_CreateEmployeeClassificationIntoDataView(XPDataView dataView, Session session, string EmployeeClassificationName, bool IsExempt, bool IsEmployee)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("HR.CreateEmployeeClassification", new OperandValue(EmployeeClassificationName), new OperandValue(IsExempt), new OperandValue(IsEmployee));
            dataView.PopulateProperties(session.GetClassInfo(typeof(CreateEmployeeClassificationResult)));
            dataView.LoadData(sprocData);
        }


        public static DevExpress.Xpo.DB.SelectedData ExecHR_GetEmployeeClassifications(Session session, int EmployeeClassificationKey)
        {
            return session.ExecuteSproc("HR.GetEmployeeClassifications", new OperandValue(EmployeeClassificationKey));
        }
        public static System.Collections.Generic.ICollection<GetEmployeeClassificationsResult> ExecHR_GetEmployeeClassificationsIntoObjects(Session session, int? EmployeeClassificationKey)
        {
            return session.GetObjectsFromSproc<GetEmployeeClassificationsResult>("HR.GetEmployeeClassifications", new OperandValue(EmployeeClassificationKey));
        }
        public static XPDataView ExecHR_GetEmployeeClassificationsIntoDataView(Session session, int EmployeeClassificationKey)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("HR.GetEmployeeClassifications", new OperandValue(EmployeeClassificationKey));
            return new XPDataView(session.Dictionary, session.GetClassInfo(typeof(GetEmployeeClassificationsResult)), sprocData);
        }
        public static void ExecHR_GetEmployeeClassificationsIntoDataView(XPDataView dataView, Session session, int EmployeeClassificationKey)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("HR.GetEmployeeClassifications", new OperandValue(EmployeeClassificationKey));
            dataView.PopulateProperties(session.GetClassInfo(typeof(GetEmployeeClassificationsResult)));
            dataView.LoadData(sprocData);
        }
    }
}
