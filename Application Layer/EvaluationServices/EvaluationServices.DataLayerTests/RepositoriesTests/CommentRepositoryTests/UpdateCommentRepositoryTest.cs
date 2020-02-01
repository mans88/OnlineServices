using EvaluationServices.DataLayer;
using EvaluationServices.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineServices.Common.EvaluationServices.Enumerations;
using OnlineServices.Common.EvaluationServices.Interfaces;
using OnlineServices.Common.EvaluationServices.Interfaces.Repositories;
using OnlineServices.Common.EvaluationServices.TransfertObjects;
using OnlineServices.Common.TranslationServices.TransfertObjects;
using System;
using System.Linq;
using System.Reflection;

namespace EvaluationServices.DataLayerTests.RepositoriesTests.CommentRepositoryTests
{
    [TestClass]
    public class UpdateCommentRepositoryTest
    {
        [TestMethod]
        public void UpdateCommentWithCorrectParameters()
        {
            var options = new DbContextOptionsBuilder<EvaluationContext>()
                .UseInMemoryDatabase(databaseName: MethodBase.GetCurrentMethod().Name)
                .Options;

            using (var memoryContext = new EvaluationContext(options))
            {
                //Arrange
                ICommentRepository commentRepository = new CommentRepository(memoryContext);
                IFormRepository formRepository = new FormRepository(memoryContext);
                IResponseRepository responseRepository = new ResponseRepository(memoryContext);
                IQuestionRepository questionRepository = new QuestionRepository(memoryContext);
                ISubmissionRepository submissionRepository = new SubmissionRepository(memoryContext);
                IQuestionPropositionRepository questionPropositionRepository = new QuestionPropositionRepository(memoryContext);

                #region Form

                var Form1 = new FormTO
                {
                    Name = new MultiLanguageString
                    (
                        "Daily evaluation form",
                        "Formulaire d'évaluation journalier",
                        "Dagelijks evaluatieformulier"
                    ),
                };
                var formAdded1 = formRepository.Add(Form1);
                memoryContext.SaveChanges();

                #endregion

                #region Questions

                var Question1 = new QuestionTO
                {
                    Form = formAdded1,
                    Position = 1,
                    Libelle = new MultiLanguageString
                    (
                        "What is your general impression after this first day of training ?",
                        "Quelle est votre impression générale après cette première journée de formation ?",
                        "Wat is je algemene indruk na deze eerste dag van training ?"
                    ),
                    Type = QuestionType.SingleChoice,
                };

                var Question2 = new QuestionTO
                {
                    Form = formAdded1,
                    Position = 2,
                    Libelle = new MultiLanguageString
                    (
                        "Is the pace right for you ?",
                        "Est-ce que le rythme vous convient ?",
                        "Is het tempo geschikt voor u ?"
                    ),
                    Type = QuestionType.SingleChoice,
                };

                var Question3 = new QuestionTO
                {
                    Form = formAdded1,
                    Position = 3,
                    Libelle = new MultiLanguageString
                    (
                        "Do you have questions related to the subject studied today ?",
                        "Avez-vous des questions relatives à la matière étudiée aujourd’hui ?",
                        "Heb je vragen over het onderwerp dat vandaag is bestudeerd ?"
                    ),
                    Type = QuestionType.Open
                };

                var Question4 = new QuestionTO
                {
                    Form = formAdded1,
                    Position = 4,
                    Libelle = new MultiLanguageString
                    (
                        "Do you have specific questions / particular topics that you would like deepen during this training ?",
                        "Avez-vous des questions spécifiques/sujets particuliers que vous aimeriez approfondir durant cette formation ?",
                        "Heeft u specifieke vragen / specifieke onderwerpen die u graag zou willen verdiepen tijdens deze training ?"
                    ),
                    Type = QuestionType.Open
                };

                var Question5 = new QuestionTO
                {
                    Form = formAdded1,
                    Position = 5,
                    Libelle = new MultiLanguageString
                    (
                        "What objectives do you pursue by following this training ?",
                        "Quels objectifs poursuivez-vous en suivant cette formation ?",
                        "Welke doelstellingen streeft u na door deze training te volgen?"
                    ),
                    Type = QuestionType.Open
                };

                var questionAdded1 = questionRepository.Add(Question1);
                var questionAdded2 = questionRepository.Add(Question2);
                var questionAdded3 = questionRepository.Add(Question3);
                var questionAdded4 = questionRepository.Add(Question4);
                var questionAdded5 = questionRepository.Add(Question5);
                memoryContext.SaveChanges();

                #endregion

                #region QuestionProposition
                var QuestionProposition1 = new QuestionPropositionTO
                {
                    Question = questionAdded1,
                    Libelle = new MultiLanguageString("good", "bonne", "goed"),
                    Position = 1
                };

                var QuestionProposition2 = new QuestionPropositionTO
                {
                    Question = questionAdded1,
                    Libelle = new MultiLanguageString("medium", "moyenne", "gemiddelde"),
                    Position = 2
                };

                var QuestionProposition3 = new QuestionPropositionTO
                {
                    Question = questionAdded1,
                    Libelle = new MultiLanguageString("bad", "mauvaise", "slecht"),
                    Position = 3
                };

                var QuestionProposition4 = new QuestionPropositionTO
                {
                    Question = questionAdded2,
                    Libelle = new MultiLanguageString("yes", "oui", "ja"),
                    Position = 1
                };

                var QuestionProposition5 = new QuestionPropositionTO
                {
                    Question = questionAdded2,
                    Libelle = new MultiLanguageString("too fast", "trop rapide", "te snel"),
                    Position = 2
                };

                var QuestionProposition6 = new QuestionPropositionTO
                {
                    Question = questionAdded2,
                    Libelle = new MultiLanguageString("too slow", "trop lent", "te langzaam"),
                    Position = 3
                };

                var questionPropositionAdded1 = questionPropositionRepository.Add(QuestionProposition1);
                var questionPropositionAdded2 = questionPropositionRepository.Add(QuestionProposition2);
                var questionPropositionAdded3 = questionPropositionRepository.Add(QuestionProposition3);
                var questionPropositionAdded4 = questionPropositionRepository.Add(QuestionProposition4);
                var questionPropositionAdded5 = questionPropositionRepository.Add(QuestionProposition5);
                var questionPropositionAdded6 = questionPropositionRepository.Add(QuestionProposition6);

                memoryContext.SaveChanges();

                #endregion

                #region Submission
                var submission1 = new SubmissionTO
                {
                    SessionId = 30,
                    AttendeeId = 1012,
                    Date = DateTime.Today,
                };
                var submission2 = new SubmissionTO
                {
                    SessionId = 31,
                    AttendeeId = 2607,
                    Date = DateTime.Today,
                };
                var submission3 = new SubmissionTO
                {
                    SessionId = 2,
                    AttendeeId = 1612,
                    Date = DateTime.Today,
                };

                var submissionAdded1 = submissionRepository.Add(submission1);
                var submissionAdded2 = submissionRepository.Add(submission2);
                var submissionAdded3 = submissionRepository.Add(submission3);
                memoryContext.SaveChanges();

                #endregion

                #region Responses
                var response1 = new ResponseTO
                {
                    Question = questionAdded1,
                    Submission = submissionAdded1,
                    QuestionProposition = questionPropositionAdded1,
                };

                var response2 = new ResponseTO
                {
                    Question = questionAdded2,
                    Submission = submissionAdded2,
                    QuestionProposition = questionPropositionAdded2,
                };

                var response3 = new ResponseTO
                {
                    Question = questionAdded3,
                    Submission = submissionAdded3,
                    Text = "Ceci est une réponse à une question ouverte",
                    //QuestionProposition = QuestionProposition3,
                };

                var response4 = new ResponseTO
                {
                    Question = questionAdded4,
                    Submission = submissionAdded1,
                    Text = "Ceci est une réponse à une question ouverte",
                };

                //Assert
                var responseAdded1 = responseRepository.Add(response1);
                var responseAdded2 = responseRepository.Add(response2);
                var responseAdded3 = responseRepository.Add(response3);
                var responseAdded4 = responseRepository.Add(response4);
                memoryContext.SaveChanges();

                #endregion

                #region Comment
                var comment1 = new CommentTO
                {
                    Response = responseAdded1,
                    Content = "ceci est un commentaire"
                };

                var comment2 = new CommentTO
                {
                    Response = responseAdded2,
                    Content = "ceci est un commentaire"
                };

                var commentAdded1 = commentRepository.Add(comment1);
                var commentAdded2 = commentRepository.Add(comment2);
                memoryContext.SaveChanges();
                #endregion

                //Act
                var result1 = commentRepository.Remove(commentAdded1);
                //var result2 = commentRepository.Remove(commentAdded2);
                memoryContext.SaveChanges();

                var commentToUpadet = new CommentTO
                {
                    Id = commentAdded2.Id,
                    Content = "update comment",
                    Response=commentAdded2.Response,
                };

                var result = commentRepository.Update(commentToUpadet);

                //Assert
                Assert.IsTrue(result1);
                Assert.AreEqual("update comment", result.Content);
            }
        }
    }
}

