﻿using InsuraNex.Data;
using InsuraNex.Models.Domain;

namespace InsuraNex.Repositories
{
    public class PolicyOpsRepository(RazorPagesDBContext razorPagesDBContext) : IPolicyOpsRepository
    {
        public async Task<InsurancePlans> AddAsync(InsurancePlans insurance)
        {
            razorPagesDBContext.PolicyInformation.AddAsync(insurance);
            razorPagesDBContext.SaveChanges();

            return insurance;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existingPolicy = razorPagesDBContext.PolicyInformation.Find(id);

            if (existingPolicy != null)
            {
                razorPagesDBContext.PolicyInformation.Remove(existingPolicy);
                razorPagesDBContext.SaveChanges();
                return true;
            }
            
            return false;
        }

        public RazorPagesDBContext? GetRazorPagesDBContext()
        {
            return razorPagesDBContext;
        }


        public async Task<IEnumerable<InsurancePlans>> GetAllAsync()
        {
            return razorPagesDBContext.PolicyInformation.ToList();
        }

        public async Task<InsurancePlans> GetAsync(Guid id)
        {
            return razorPagesDBContext.PolicyInformation.Find(id);
        }

        public async Task<InsurancePlans> UpdateAsync(InsurancePlans insurance)
        {

            InsurancePlans? existingPolicy = (insurance != null) ? razorPagesDBContext.PolicyInformation.Find(insurance.Id) : null;

            if (existingPolicy != null)
            {
                existingPolicy.PolicyName = insurance.PolicyName;
                existingPolicy.PolicyStatus = insurance.PolicyStatus;
                existingPolicy.SumAssured = insurance.SumAssured;
                existingPolicy.PlanType = insurance.PlanType;
                existingPolicy.EffectiveDate = insurance.EffectiveDate;
                existingPolicy.Features = insurance.Features;
                existingPolicy.Frequency = insurance.Frequency;
                existingPolicy.KeyBenefits = insurance.KeyBenefits;
                existingPolicy.ProductSummary = insurance.ProductSummary;
                existingPolicy.MaxAge = insurance.MaxAge;
                existingPolicy.MinAge = insurance.MinAge;
                existingPolicy.FeaturedImageUrl = insurance.FeaturedImageUrl;
                existingPolicy.UrlHandle  = insurance.UrlHandle;
                existingPolicy.Term = insurance.Term;
            }

            razorPagesDBContext.SaveChanges();
            
            return existingPolicy;
            
        }
    }
}
