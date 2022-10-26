using DAL;
using Microsoft.EntityFrameworkCore;
using Service.DTOs;
using System.Data.SqlClient;
using System.Threading.Tasks.Dataflow;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using DAL.Models;
using Exception = System.Exception;
using System.Numerics;
using Service.Interfaces;

namespace Service
{
    public class DebitService : IDebitService
    {
        private ProjectContext _projectContext;

        public DebitService(ProjectContext context)
        {
            _projectContext = context;
        }

        public List<DebitDTO> GetAllDebits()
        {
            var result = (from d in _projectContext.Debits
                          select new DebitDTO()
                          {
                              Id = d.Id,
                              Date = d.Date,
                              Amount = d.Amount,
                              Comment = d.Comment,
                              Category = d.Category == null ? string.Empty : d.Category.Name,
                              Budget = d.Budget == null ? string.Empty : d.Budget.Name,
                              UserFirstName = d.User.FirstName,
                          }).ToList();
            return result;
        }

        public List<DebitDTO> GetDebitListForUser(UserIdDTO userId)
        {
            var result = (from d in _projectContext.Debits
                          where d.UserId == userId.UserId
                          select new DebitDTO()
                          {
                              Id = d.Id,
                              Date = d.Date,
                              Amount = d.Amount,
                              Comment = d.Comment,
                              Category = d.Category == null ? string.Empty : d.Category.Name,
                              Budget = d.Budget == null ? string.Empty : d.Budget.Name,
                              UserFirstName = d.User.FirstName,
                          }).OrderByDescending(x => x.Date).ToList();
            return result;
        }

        public void CreateDebit(CreateDebitDTO debit)
        {
            _projectContext.Add(new Debit
            {
                Id = Guid.NewGuid(),
                UserId = debit.UserId,
                Date = debit.Date,
                Amount = debit.Amount,
                Comment = debit.Comment,
                CategoryId = debit.CategoryId,
                BudgetId = debit.BudgetId,
            });
            _projectContext.SaveChanges();
        }

        public GetExpenseForSpecificBudgetOutputDTO GetDebitsForBudget(GetDebitsDTO input)
        {
            var budget = _projectContext.Budgets.FirstOrDefault(b => b.Id == input.CollectionId);
            var debits = _projectContext.Debits.Where(d => d.UserId == input.UserId && d.BudgetId == input.CollectionId)
                .ToList();

            var tempList = debits.Select(item => new GEFSBODebitDTO()
            {
                ExpenseId = item.Id,
                Amount = item.Amount,
                Date = item.Date,
                Comment = item.Comment ?? string.Empty,
                CategoryName = item.Category?.Name ?? string.Empty,
                CategoryId = item.CategoryId ?? Guid.Empty,
            }).ToList();

            if (budget == null) throw new NullReferenceException($"No such Budget found!");
            var result = new GetExpenseForSpecificBudgetOutputDTO()
            {
                BudgetId = budget.Id,
                BudgetName = budget.Name,
                Debits = tempList
            };
            return result;
        }

        public DebitsInCategoryDTO GetDebitsForCategory(GetDebitsDTO input)
        {
            var category = _projectContext.Categories.FirstOrDefault(b => b.Id == input.CollectionId);
            var debits = _projectContext.Debits.Where(d => d.UserId == input.UserId && d.CategoryId == input.CollectionId).ToList();

            var tempList = debits.Select(item => new DebitItemInCategoryListDTO()
            {
                DebitId = item.Id,
                Amount = item.Amount,
                Date = item.Date,
                Comment = item.Comment ?? string.Empty,
            }).ToList();

            var result = new DebitsInCategoryDTO()
            {
                CategoryId = category.Id,
                CategoryName = category.Name,
                Debits = tempList
            };
            return result;
        }

        public void DeleteDebit(Guid debitId)
        {
            try
            {
                var result = _projectContext.Debits.FirstOrDefault(x => x.Id == debitId);

                if (result != null)
                {
                    _projectContext.Debits.Remove(result);
                    _projectContext.SaveChanges();
                }
                else { throw new NullReferenceException($"No such debit found!"); }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public void EditDebit(EditDebitDTO editDebit)
        {
            var debit = _projectContext.Debits.FirstOrDefault(x => x.Id == editDebit.DebitId);
            if (debit == null)
            {
                throw new NullReferenceException($"No Plan!");
            }
            debit.Id = editDebit.DebitId;
            debit.UserId = editDebit.UserId;
            debit.Date = editDebit.Date;
            debit.Amount = editDebit.Amount;
            debit.Comment = editDebit.Comment;
            debit.CategoryId = editDebit.CategoryId;
            debit.BudgetId = editDebit.BudgetId;
            _projectContext.SaveChanges();
        }
    }
}