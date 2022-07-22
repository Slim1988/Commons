namespace ATR.Common.Helpers.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ATR.Common.Logging;
    using ATR.Common.Models;
    using ATR.Common.Models.Requests;

    public static class TcuCgvHelper
    {
        /// <summary>
        /// Check Tcu and Cgv Link for an entity, if missing they are created
        /// </summary>
        /// <param name="idEntity">The id entity</param>
        /// <returns>1 if OK</returns>
        public static int CheckTcuCgvLink(int idEntity)
        {
            try
            {
                ENTITY entity = new ENTITY();
                entity = DataModelRequests.GetEntityById(idEntity);

                // Publish TCU or CGV case
                CGV cgvPublished = DataModelRequests.GetAllCGV().OrderByDescending(c => c.ID_CGV).Where(cgv => cgv.PUBLICATION_DATE_CGV != null && cgv.APPLICATION_DATE_CGV == null).FirstOrDefault();
                TCU tcuPublished = DataModelRequests.GetAllTCU().OrderByDescending(c => c.ID_TCU).Where(cgv => cgv.PUBLICATION_DATE_TCU != null && cgv.APPLICATION_DATE_TCU == null).FirstOrDefault();

                if (cgvPublished != null)
                {
                    List<ENTITY_CGV> entityCgvList = DataModelRequests.GetAllEntityCGV(entity.ID_ENTITY);

                    if (entityCgvList.Where(e => e.FK_CGV == cgvPublished.ID_CGV).FirstOrDefault() == null)
                    {
                        // Add link to cgv published
                        ENTITY_CGV entityCgv = new ENTITY_CGV();
                        entityCgv.FK_CGV = cgvPublished.ID_CGV;
                        entityCgv.FK_ENTITY = entity.ID_ENTITY;

                        DataModelRequests.AddENTITY_CGV(new List<ENTITY_CGV>() { entityCgv });
                        LoggingService.Application.Info(string.Format($"Add link to cgv published ID_ENTITY:{entity.ID_ENTITY} ID_CGV:{cgvPublished.ID_CGV}"));
                    }
                }

                if (tcuPublished != null)
                {
                    List<ENTITY_TCU> entityTcuList = DataModelRequests.GetAllEntityTCU(entity.ID_ENTITY);

                    if (entityTcuList.Where(e => e.FK_TCU == tcuPublished.ID_TCU).FirstOrDefault() == null)
                    {
                        // Add link to tcu published
                        ENTITY_TCU entityTcu = new ENTITY_TCU();
                        entityTcu.FK_TCU = tcuPublished.ID_TCU;
                        entityTcu.FK_ENTITY = entity.ID_ENTITY;

                        DataModelRequests.AddENTITY_TCU(new List<ENTITY_TCU>() { entityTcu });
                        LoggingService.Application.Info(string.Format($"Add link to tcu published ID_ENTITY:{entity.ID_ENTITY} ID_TCU:{tcuPublished.ID_TCU}"));
                    }
                }

                // Applicable TCU or CGV case
                CGV cgvApplicable = GetApplicableCGV();
                TCU tcuApplicable = GetApplicableTCU();

                USERS admin = DataModelRequests.GetEntityAdministrators(entity.ID_ENTITY).FirstOrDefault();

                if (cgvApplicable != null)
                {
                    List<ENTITY_CGV> entityCgvList = DataModelRequests.GetAllEntityCGV(entity.ID_ENTITY);

                    if (entityCgvList.Where(e => e.FK_CGV == cgvApplicable.ID_CGV).FirstOrDefault() == null)
                    {
                        // Add link to cgv applicable
                        ENTITY_CGV entityCgv = new ENTITY_CGV();
                        entityCgv.FK_CGV = cgvApplicable.ID_CGV;
                        entityCgv.FK_ENTITY = entity.ID_ENTITY;

                        if (entity.E_SPARE_CGV != null && entity.E_SPARE_CGV.Value)
                        {
                            entityCgv.SIGNATURE_DATE_ENTITY_CGV = entity.E_SPARE_CGV_DATE.HasValue ? entity.E_SPARE_CGV_DATE : DateTime.Now;
                            entityCgv.SIGNATURE_USER_ENTITY_CGV = admin != null ? string.Format($"{admin.LAST_NAME} {admin.FIRST_NAME} ({admin.USER_LOGIN}) {admin.EMAIL_ADDRESS}") : "Signed by Admin in Registration pages";
                        }

                        DataModelRequests.AddENTITY_CGV(new List<ENTITY_CGV>() { entityCgv });
                        LoggingService.Application.Info(string.Format($"Add link to cgv applicable ID_ENTITY:{entity.ID_ENTITY} ID_CGV:{cgvApplicable.ID_CGV}"));
                    }
                }

                if (tcuApplicable != null)
                {
                    List<ENTITY_TCU> entityTcuList = DataModelRequests.GetAllEntityTCU(entity.ID_ENTITY);

                    if (entityTcuList.Where(e => e.FK_TCU == tcuApplicable.ID_TCU).FirstOrDefault() == null)
                    {
                        // Add link to tcu applicable
                        ENTITY_TCU entityTcu = new ENTITY_TCU();
                        entityTcu.FK_TCU = tcuApplicable.ID_TCU;
                        entityTcu.FK_ENTITY = entity.ID_ENTITY;

                        if (entity.PORTAL_TC)
                        {
                            entityTcu.SIGNATURE_DATE_ENTITY_TCU = entity.SUBSCRIPTION_DATE.HasValue ? entity.SUBSCRIPTION_DATE : DateTime.Now;
                            entityTcu.SIGNATURE_USER_ENTITY_TCU = admin != null ? string.Format($"{admin.LAST_NAME} {admin.FIRST_NAME} ({admin.USER_LOGIN}) {admin.EMAIL_ADDRESS}") : "Signed by Admin in Registration pages";
                        }

                        DataModelRequests.AddENTITY_TCU(new List<ENTITY_TCU>() { entityTcu });
                        LoggingService.Application.Info(string.Format($"Add link to tcu applicable ID_ENTITY:{entity.ID_ENTITY} ID_TCU:{tcuApplicable.ID_TCU}"));
                    }
                }

                return 1;
            }
            catch (Exception ex)
            {
                LoggingService.Application.Error(ex);

                return -1;
            }
        }

        /// <summary>
        /// Get the CGV applicable
        /// </summary>
        /// <returns>The CGV applicable</returns>
        public static CGV GetApplicableCGV()
        {
            return DataModelRequests.GetAllCGV().OrderByDescending(c => c.ID_CGV).Where(cgv => cgv.PUBLICATION_DATE_CGV != null && cgv.APPLICATION_DATE_CGV != null).FirstOrDefault();
        }

        /// <summary>
        /// Get the TCU applicable
        /// </summary>
        /// <returns>The TCU applicable</returns>
        public static TCU GetApplicableTCU()
        {
            return DataModelRequests.GetAllTCU().OrderByDescending(c => c.ID_TCU).Where(cgv => cgv.PUBLICATION_DATE_TCU != null && cgv.APPLICATION_DATE_TCU != null).FirstOrDefault();
        }
    }
}
