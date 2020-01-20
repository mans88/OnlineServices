using OnlineServices.Common.EvaluationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationServices.DataLayer
{
    public class ESUnitOfWork : IESUnitOfWork, IDisposable
    {
        private readonly EvaluationContext evaluationContext;



        public ESUnitOfWork(EvaluationContext evaluationContext)
        {
            this.evaluationContext = evaluationContext ?? throw new ArgumentNullException(nameof(evaluationContext));
        }


        private bool disposed = false;

        private IQuestionRepository questionRepository;
        public IQuestionRepository QuestionRepository => questionRepository = new QuestionRepository(evaluationContext);

        private IResponseRepository responseRepository;
        public IResponseRepository ResponseRepository => responseRepository = new ResponseRepository(evaluationContext);

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)

                {
                    evaluationContext.Dispose();
                }
            }
            disposed = true;
        }



        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int SaveChanges()
        {
            return evaluationContext.SaveChanges();
        }
    }
}
