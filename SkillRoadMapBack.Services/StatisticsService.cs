using AutoMapper;
using SkillRoadmapBack.Core.Abstractions;
using SkillRoadmapBack.Core.Abstractions.IServices;
using SkillRoadmapBack.Core.DTO.StandardDTO;
using SkillRoadmapBack.Core.Models;
using SkillRoadMapBack.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillRoadMapBack.Services
{
    public class StatisticsService : BaseService, IStatisticsService
    {
        public StatisticsService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public virtual async Task CreateAsync(StatisticsDTO entity)
        {
            var value = new Statistics();
            _mapper.Map(entity, value);
            await _unitOfWork.StatisticsRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.StatisticsRepo.GetByIdAsync(id);
            await _unitOfWork.StatisticsRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<StatisticsDTO>> GetAll()
        {
            var statisticses = await _unitOfWork.StatisticsRepo.GetAllAsync();
            List<StatisticsDTO> statisticsDTOs = statisticses.Select(statistics => _mapper.Map(statistics, new StatisticsDTO())).ToList();
            return statisticsDTOs;
        }

        public virtual async Task<StatisticsDTO> GetIdAsync(int id)
        {
            var statistics = await _unitOfWork.StatisticsRepo.GetByIdAsync(id);
            if (statistics == null)
                throw new Exception("Such category not found");
            var dto = new StatisticsDTO();
            _mapper.Map(statistics, dto);
            return dto;
        }

        public virtual async Task<StatisticsDTO> UpdateAsync(StatisticsDTO entity)
        {
            var value = new Statistics();
            _mapper.Map(entity, value);
            await _unitOfWork.StatisticsRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<StatisticsDTO> UpdateStats(string email, int year)
        {
            var emp = (await _unitOfWork.EmployeeRepo.GetAllAsync()).FirstOrDefault(e => e.Email == email);
            var myStats = (await _unitOfWork.StatisticsRepo.GetAllAsync()).FirstOrDefault(s => s.IdEmployee == emp.Id && s.StatYear == year);

            var skills = (await _unitOfWork.UserSkillRepo.GetAllAsync()).Where(skill => skill.IdEmployee == emp.Id && skill.EndDate.Year == year);

            if (myStats != null)
            {
                myStats.NewSkillCount = skills.Count();
                //myStats.StatYear = year;
                //myStats.IdEmployee = emp.Id;

                TimeSpan allTimeDiff = new TimeSpan(0,0,0,0);
                int sumLevel = 0;
                foreach (var skill in skills)
                {
                    TimeSpan tmpSpan = skill.EndDate.Subtract(skill.StartDate);
                    allTimeDiff = allTimeDiff.Add(tmpSpan);
                    sumLevel += skill.SkillLevel;
                }
                myStats.StudyingTime = allTimeDiff.Days;
                myStats.AverageSkillLevel = sumLevel / skills.Count();

                var anotherStats = (await _unitOfWork.StatisticsRepo.GetAllAsync()).Where(stat => stat.StatYear == year);
                if (anotherStats == null || anotherStats.Count() == 0)
                {
                    myStats.BetterThanPercent = 100;
                }
                else
                {
                    int MaxNewSkill = anotherStats.Max(stat => stat.NewSkillCount);
                    double NewSkillPercent = 0, StudyingTimePercent = 0, AverageSkillPercent = 0;
                    if (MaxNewSkill == 0)
                    {
                        NewSkillPercent = 100;
                    }
                    else
                    {
                        NewSkillPercent = myStats.NewSkillCount * 1.0 / MaxNewSkill * 100;
                    }
                    long MaxStudyingTime = anotherStats.Max(stat => stat.StudyingTime);
                    if (MaxStudyingTime == 0)
                    {
                        StudyingTimePercent = 100;
                    }
                    else
                    {
                        StudyingTimePercent = myStats.StudyingTime * 1.0 / MaxStudyingTime * 100;
                    }
                    double MaxAverageSkill = anotherStats.Max(stat => stat.AverageSkillLevel);
                    if (MaxAverageSkill == 0)
                    {
                        AverageSkillPercent = 100;
                    }
                    else
                    {
                        AverageSkillPercent = myStats.AverageSkillLevel * 1.0 / MaxAverageSkill * 100;
                    }
                    myStats.BetterThanPercent = (NewSkillPercent + StudyingTimePercent + AverageSkillPercent) / 3;
                }
                await _unitOfWork.StatisticsRepo.UpdateAsync(myStats);
                await _unitOfWork.SaveChangesAsync();
            }
            else
            {
                myStats = new Statistics();
                myStats.NewSkillCount = skills.Count();
                myStats.StatYear = year;
                myStats.IdEmployee = emp.Id;

                TimeSpan allTimeDiff = new TimeSpan(0);
                int sumLevel = 0;
                foreach (var skill in skills)
                {
                    allTimeDiff.Add(skill.EndDate.Subtract(skill.StartDate));
                    sumLevel += skill.SkillLevel;
                }
                myStats.StudyingTime = allTimeDiff.Days;
                myStats.AverageSkillLevel = sumLevel / skills.Count();

                var anotherStats = (await _unitOfWork.StatisticsRepo.GetAllAsync()).Where(stat => stat.StatYear == year);
                if (anotherStats == null || anotherStats.Count() == 0)
                {
                    myStats.BetterThanPercent = 100;
                }
                else
                {
                    int MaxNewSkill = anotherStats.Max(stat => stat.NewSkillCount);
                    double NewSkillPercent = 0, StudyingTimePercent = 0, AverageSkillPercent = 0;
                    if (MaxNewSkill == 0)
                    {
                        NewSkillPercent = 100;
                    }
                    else
                    {
                        NewSkillPercent = myStats.NewSkillCount * 1.0 / MaxNewSkill * 100;
                    }
                    long MaxStudyingTime = anotherStats.Max(stat => stat.StudyingTime);
                    if (MaxStudyingTime == 0)
                    {
                        StudyingTimePercent = 100;
                    }
                    else
                    {
                        StudyingTimePercent = myStats.StudyingTime * 1.0 / MaxStudyingTime * 100;
                    }
                    double MaxAverageSkill = anotherStats.Max(stat => stat.AverageSkillLevel);
                    if (MaxAverageSkill == 0)
                    {
                        AverageSkillPercent = 100;
                    }
                    else
                    {
                        AverageSkillPercent = myStats.AverageSkillLevel * 1.0 / MaxAverageSkill * 100;
                    }
                    myStats.BetterThanPercent = (NewSkillPercent + StudyingTimePercent + AverageSkillPercent) / 3;
                }
                await _unitOfWork.StatisticsRepo.AddAsync(myStats);
                await _unitOfWork.SaveChangesAsync();
            }
            var dto = new StatisticsDTO();
            _mapper.Map(myStats, dto);
            return dto;
        }


        public virtual async Task<StatisticsDTO> UpdateStats(int userId, int year)
        {
            var emp = (await _unitOfWork.EmployeeRepo.GetAllAsync()).FirstOrDefault(e => e.Id == userId);
            var myStats = (await _unitOfWork.StatisticsRepo.GetAllAsync()).FirstOrDefault(s => s.IdEmployee == emp.Id && s.StatYear == year);

            var skills = (await _unitOfWork.UserSkillRepo.GetAllAsync()).Where(skill => skill.IdEmployee == emp.Id && skill.EndDate.Year == year);

            if (myStats != null)
            {
                myStats.NewSkillCount = skills.Count();
                //myStats.StatYear = year;
                //myStats.IdEmployee = emp.Id;

                TimeSpan allTimeDiff = new TimeSpan(0, 0, 0, 0);
                int sumLevel = 0;
                foreach (var skill in skills)
                {
                    TimeSpan tmpSpan = skill.EndDate.Subtract(skill.StartDate);
                    allTimeDiff = allTimeDiff.Add(tmpSpan);
                    sumLevel += skill.SkillLevel;
                }
                myStats.StudyingTime = allTimeDiff.Days;
                myStats.AverageSkillLevel = sumLevel / skills.Count();

                var anotherStats = (await _unitOfWork.StatisticsRepo.GetAllAsync()).Where(stat => stat.StatYear == year);
                if (anotherStats == null || anotherStats.Count() == 0)
                {
                    myStats.BetterThanPercent = 100;
                }
                else
                {
                    int MaxNewSkill = anotherStats.Max(stat => stat.NewSkillCount);
                    double NewSkillPercent = 0, StudyingTimePercent = 0, AverageSkillPercent = 0;
                    if (MaxNewSkill == 0)
                    {
                        NewSkillPercent = 100;
                    }
                    else
                    {
                        NewSkillPercent = myStats.NewSkillCount * 1.0 / MaxNewSkill * 100;
                    }
                    long MaxStudyingTime = anotherStats.Max(stat => stat.StudyingTime);
                    if (MaxStudyingTime == 0)
                    {
                        StudyingTimePercent = 100;
                    }
                    else
                    {
                        StudyingTimePercent = myStats.StudyingTime * 1.0 / MaxStudyingTime * 100;
                    }
                    double MaxAverageSkill = anotherStats.Max(stat => stat.AverageSkillLevel);
                    if (MaxAverageSkill == 0)
                    {
                        AverageSkillPercent = 100;
                    }
                    else
                    {
                        AverageSkillPercent = myStats.AverageSkillLevel * 1.0 / MaxAverageSkill * 100;
                    }
                    myStats.BetterThanPercent = (NewSkillPercent + StudyingTimePercent + AverageSkillPercent) / 3;
                }
                await _unitOfWork.StatisticsRepo.UpdateAsync(myStats);
                await _unitOfWork.SaveChangesAsync();
            }
            else
            {
                myStats = new Statistics();
                myStats.NewSkillCount = skills.Count();
                myStats.StatYear = year;
                myStats.IdEmployee = emp.Id;

                TimeSpan allTimeDiff = new TimeSpan(0);
                int sumLevel = 0;
                foreach (var skill in skills)
                {
                    allTimeDiff.Add(skill.EndDate.Subtract(skill.StartDate));
                    sumLevel += skill.SkillLevel;
                }
                myStats.StudyingTime = allTimeDiff.Days;
                myStats.AverageSkillLevel = sumLevel / skills.Count();

                var anotherStats = (await _unitOfWork.StatisticsRepo.GetAllAsync()).Where(stat => stat.StatYear == year);
                if (anotherStats == null || anotherStats.Count() == 0)
                {
                    myStats.BetterThanPercent = 100;
                }
                else
                {
                    int MaxNewSkill = anotherStats.Max(stat => stat.NewSkillCount);
                    double NewSkillPercent = 0, StudyingTimePercent = 0, AverageSkillPercent = 0;
                    if (MaxNewSkill == 0)
                    {
                        NewSkillPercent = 100;
                    }
                    else
                    {
                        NewSkillPercent = myStats.NewSkillCount * 1.0 / MaxNewSkill * 100;
                    }
                    long MaxStudyingTime = anotherStats.Max(stat => stat.StudyingTime);
                    if (MaxStudyingTime == 0)
                    {
                        StudyingTimePercent = 100;
                    }
                    else
                    {
                        StudyingTimePercent = myStats.StudyingTime * 1.0 / MaxStudyingTime * 100;
                    }
                    double MaxAverageSkill = anotherStats.Max(stat => stat.AverageSkillLevel);
                    if (MaxAverageSkill == 0)
                    {
                        AverageSkillPercent = 100;
                    }
                    else
                    {
                        AverageSkillPercent = myStats.AverageSkillLevel * 1.0 / MaxAverageSkill * 100;
                    }
                    myStats.BetterThanPercent = (NewSkillPercent + StudyingTimePercent + AverageSkillPercent) / 3;
                }
                await _unitOfWork.StatisticsRepo.AddAsync(myStats);
                await _unitOfWork.SaveChangesAsync();
            }
            var dto = new StatisticsDTO();
            _mapper.Map(myStats, dto);
            return dto;
        }
    }
}
