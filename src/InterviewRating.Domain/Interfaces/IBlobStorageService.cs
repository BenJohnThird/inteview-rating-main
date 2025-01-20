﻿namespace InterviewRating.Domain.Interfaces;

public interface IBlobStorageService
{
    Task<string> UploadToBlobAsync(Stream data, string fileName);
}
