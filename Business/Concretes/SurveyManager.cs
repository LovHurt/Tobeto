﻿using AutoMapper;
using Business.DTOs.Request.Survey;
using Business.DTOs.Response.Survey;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.Surveys;
using Microsoft.EntityFrameworkCore;



public class SurveyManager : ISurveyService
{
    private readonly ISurveyDal _surveyDal;
    private readonly IMapper _mapper;

    public SurveyManager(ISurveyDal surveyDal, IMapper mapper)
    {
        _surveyDal = surveyDal;
        _mapper = mapper;
    }

    public async Task<CreatedSurveyResponse> Add(CreateSurveyRequest createSurveyRequest)
    {
        Survey survey = _mapper.Map<Survey>(createSurveyRequest);
        Survey createdSurvey = await _surveyDal.AddAsync(survey);
        CreatedSurveyResponse createdSurveyResponse = _mapper.Map<CreatedSurveyResponse>(createdSurvey);
        return createdSurveyResponse;
    }

    public async Task<DeletedSurveyResponse> Delete(DeleteSurveyRequest deleteSurveyRequest)
    {
        var data = await _surveyDal.GetAsync(i => i.Id == deleteSurveyRequest.Id);
        _mapper.Map(deleteSurveyRequest, data);
        var result = await _surveyDal.DeleteAsync(data);
        var result2 = _mapper.Map<DeletedSurveyResponse>(result);
        return result2;
    }

    public async Task<GetByIdSurveyResponse> GetById(int id)
    {
        var result = await _surveyDal.GetAsync(
            s => s.Id == id,
            include: sa => sa.Include(sa => sa.SurveyQuestions.Where(sq => sq.SurveyID == id))
        );

        Console.WriteLine("Gelen result: " + result);

        GetByIdSurveyResponse customResponse = _mapper.Map<GetByIdSurveyResponse>(result);

        // Özel survey question response'ları oluştur
        customResponse.SurveyQuestions = result.SurveyQuestions
            .Select(sq => new GetSurveyQuestionResponse
            {
                QuestionId = sq.Id,
                QuestionText = sq.QuestionText,
                QuestionType = sq.QuestionType
                // Diğer özellikler...
            })
            .ToList();

        return customResponse;
    }


    public async Task<IPaginate<GetListSurveyResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _surveyDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize
        );
        var result = _mapper.Map<Paginate<GetListSurveyResponse>>(data);
        return result;
    }

    public async Task<UpdatedSurveyResponse> Update(UpdateSurveyRequest updateSurveyRequest)
    {
        var data = await _surveyDal.GetAsync(i => i.Id == updateSurveyRequest.Id);
        _mapper.Map(updateSurveyRequest, data);
        await _surveyDal.UpdateAsync(data);
        var result = _mapper.Map<UpdatedSurveyResponse>(data);
        return result;
    }
    public async Task<List<GetListSurveyResponse>> GetUnsentSurveysAsync(Guid userId)
    {

        var answeredSurveyIds = await _surveyDal.GetListAsync(sa => sa.SurveyAnswers.Any(sar => sar.UserID == userId));
        var allSurveyIds = await _surveyDal.GetListAsync(size: int.MaxValue, index: 0);
        var unsentSurveyIds = allSurveyIds.Items.Select(s => s.Id).Except(answeredSurveyIds.Items.Select(sa => sa.Id)).ToList();

        var unsentSurveysResult = await _surveyDal.GetListAsync(survey => unsentSurveyIds.Contains(survey.Id));

        // Items özelliği üzerinden anketlere eriş ve projeksiyon yap
        var unsentSurveyResponses = unsentSurveysResult.Items
            .OfType<Survey>() // Eğer Items bir IEnumerable ise, OfType ile uygun tipi seçebilirsiniz.
            .Select(survey => _mapper.Map<GetListSurveyResponse>(survey))
            .ToList();

        return unsentSurveyResponses;
    }




}