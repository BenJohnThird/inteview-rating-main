﻿using Azure.Storage.Blobs;
using InterviewRating.Domain.Interfaces;
using InterviewRating.Infrastructure.Configuration;
using Microsoft.Extensions.Options;

namespace InterviewRating.Infrastructure.Storage;

public class BlobStorageService(
    IOptions<BlobStorageSettings> blobStorageSettingsOptions
    ) : IBlobStorageService
{
    private readonly BlobStorageSettings _blobStorageSettings = blobStorageSettingsOptions.Value;

    public async Task<string> UploadToBlobAsync(Stream data, string fileName)
    {
        var blobServiceClient = new BlobServiceClient(_blobStorageSettings.ConnectionString);
        var containerClient = blobServiceClient.GetBlobContainerClient(_blobStorageSettings.LogosContainerName);

        var blobClient = containerClient.GetBlobClient(fileName);

        await blobClient.UploadAsync(data);

        var blobUrl = blobClient.Uri.ToString();
        return blobUrl;
    }
}
