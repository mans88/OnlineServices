using FacilityServices.DataLayer.Entities;
using OnlineServices.Common.Extensions;
using OnlineServices.Common.FacilityServices.Exceptions;
using OnlineServices.Common.FacilityServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacilityServices.DataLayer.Extensions
{
    public static class IssueExtensions
    {
        public static IssueTO ToTransfertObject(this IssueEF Issue)
        {
            if (Issue is null)
                throw new NullIssueException(nameof(Issue));

            return new IssueTO
            {
                Id = Issue.Id,
                Name = new MultiLanguageString(Issue.NameEnglish, Issue.NameFrench, Issue.NameDutch),
                ComponentType = Issue.ComponentType.ToTransfertObject(),
                Archived = Issue.Archived,
                Description = Issue.Description,
            };
        }

        public static IssueEF ToEF(this IssueTO Issue)
        {
            if (Issue is null)
                throw new NullIssueException(nameof(Issue));

            return new IssueEF
            {
                Id = Issue.Id,
                NameEnglish = Issue.Name.English,
                NameFrench = Issue.Name.French,
                NameDutch = Issue.Name.Dutch,
                ComponentType = Issue.ComponentType.ToEF(),
                Archived = Issue.Archived,
                Description = Issue.Description,
            };
        }

        public static IssueEF UpdateFromDetached(this IssueEF AttachedEF, IssueEF DetachedEF)
        {
            if (AttachedEF is null)
                throw new ArgumentNullException(nameof(AttachedEF));

            if (DetachedEF is null)
                throw new ArgumentNullException(nameof(DetachedEF));

            if (AttachedEF.Id != DetachedEF.Id)
                throw new Exception("Cannot update ComponentEF entity as it is not the same.");

            if ((AttachedEF != default) && (DetachedEF != default))
            {
                AttachedEF.Description = DetachedEF.Description;
                AttachedEF.ComponentType = DetachedEF.ComponentType;
                AttachedEF.Archived = DetachedEF.Archived;
                AttachedEF = AttachedEF.FillFromMultiLanguageString(DetachedEF.ExtractToMultiLanguageString());
            }

            return AttachedEF;
        }
    }
}
