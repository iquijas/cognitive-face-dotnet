using FaceClientSDK.Domain.FaceList;
using FaceClientSDK.Tests.Fixtures;
using FaceClientSDK.Tests.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Xunit;

namespace FaceClientSDK.Tests
{
    public class FaceListTests : IClassFixture<FaceAPISettingsFixture>
    {
        private FaceAPISettingsFixture faceAPISettingsFixture = null;

        public FaceListTests(FaceAPISettingsFixture fixture)
        {
            faceAPISettingsFixture = fixture;

            APIReference.FaceAPIKey = faceAPISettingsFixture.FaceAPIKey;
            APIReference.FaceAPIZone = faceAPISettingsFixture.FaceAPIZone;
            TimeoutHelper.Timeout = faceAPISettingsFixture.Timeout;
        }

        [Fact]
        public void AddFaceAsyncTest()
        {
            TimeoutHelper.ThrowExceptionInTimeout(() =>
            {
                AddFaceResult result = null;
                var identifier = System.Guid.NewGuid().ToString();

                try
                {
                    var creation_result = APIReference.Instance.FaceListInstance.CreateAsync(identifier, identifier, identifier).Result;
                    System.Diagnostics.Trace.Write($"Creation Result: {creation_result}");

                    if (creation_result)
                    {
                        dynamic jUserData = new JObject();
                        jUserData.UserDataSample = "User Data Sample";
                        var rUserData = JsonConvert.SerializeObject(jUserData);

                        result = APIReference.Instance.FaceListInstance.AddFaceAsync(identifier, faceAPISettingsFixture.TestImageUrl, rUserData, string.Empty).Result;
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    var deletion_result = APIReference.Instance.FaceListInstance.DeleteAsync(identifier).Result;
                    System.Diagnostics.Trace.Write($"Deletion Result: {deletion_result}");
                }

                Assert.True(result != null);
            });
        }

        [Fact]
        public void CreateAsyncTest()
        {
            TimeoutHelper.ThrowExceptionInTimeout(() =>
            {
                bool result = false;
                var identifier = System.Guid.NewGuid().ToString();

                try
                {
                    result = APIReference.Instance.FaceListInstance.CreateAsync(identifier, identifier, identifier).Result;
                    System.Diagnostics.Trace.Write($"Creation Result: {result}");
                }
                catch
                {
                    throw;
                }
                finally
                {
                    var deletion_result = APIReference.Instance.FaceListInstance.DeleteAsync(identifier).Result;
                    System.Diagnostics.Trace.Write($"Deletion Result: {deletion_result}");
                }

                Assert.True(result);
            });
        }

        [Fact]
        public void DeleteAsyncTest()
        {
            TimeoutHelper.ThrowExceptionInTimeout(() =>
            {
                bool result = false;
                var identifier = System.Guid.NewGuid().ToString();

                try
                {
                    var creation_result = APIReference.Instance.FaceListInstance.CreateAsync(identifier, identifier, identifier).Result;
                    System.Diagnostics.Trace.Write($"Creation Result: {creation_result}");

                    result = APIReference.Instance.FaceListInstance.DeleteAsync(identifier).Result;
                    System.Diagnostics.Trace.Write($"Deletion Result: {result}");
                }
                catch
                {
                    throw;
                }

                Assert.True(result);
            });
        }

        [Fact]
        public void DeleteFaceAsyncTest()
        {
            TimeoutHelper.ThrowExceptionInTimeout(() =>
            {
                bool result = false;
                var identifier = System.Guid.NewGuid().ToString();

                try
                {
                    var creation_result = APIReference.Instance.FaceListInstance.CreateAsync(identifier, identifier, identifier).Result;
                    System.Diagnostics.Trace.Write($"Creation Result: {creation_result}");

                    AddFaceResult addface_result = null;
                    if (creation_result)
                    {
                        dynamic jUserData = new JObject();
                        jUserData.UserDataSample = "User Data Sample";
                        var rUserData = JsonConvert.SerializeObject(jUserData);

                        addface_result = APIReference.Instance.FaceListInstance.AddFaceAsync(identifier, faceAPISettingsFixture.TestImageUrl, rUserData, string.Empty).Result;

                        if (addface_result != null)
                            result = APIReference.Instance.FaceListInstance.DeleteFaceAsync(identifier, addface_result.persistedFaceId).Result;
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    var deletion_result = APIReference.Instance.FaceListInstance.DeleteAsync(identifier).Result;
                    System.Diagnostics.Trace.Write($"Deletion Result: {deletion_result}");
                }

                Assert.True(result);
            });
        }

        [Fact]
        public void GetAsyncTest()
        {
            TimeoutHelper.ThrowExceptionInTimeout(() =>
            {
                GetResult result = null;
                var identifier = System.Guid.NewGuid().ToString();

                try
                {
                    var creation_result = APIReference.Instance.FaceListInstance.CreateAsync(identifier, identifier, identifier).Result;
                    System.Diagnostics.Trace.Write($"Creation Result: {creation_result}");

                    if (creation_result)
                        result = APIReference.Instance.FaceListInstance.GetAsync(identifier).Result;
                }
                catch
                {
                    throw;
                }
                finally
                {
                    var deletion_result = APIReference.Instance.FaceListInstance.DeleteAsync(identifier).Result;
                    System.Diagnostics.Trace.Write($"Deletion Result: {deletion_result}");
                }

                Assert.True(result != null);
            });
        }

        [Fact]
        public void ListAsyncTest()
        {
            TimeoutHelper.ThrowExceptionInTimeout(() =>
            {
                List<ListResult> result = null;
                var identifier = System.Guid.NewGuid().ToString();

                try
                {
                    var creation_result = APIReference.Instance.FaceListInstance.CreateAsync(identifier, identifier, identifier).Result;
                    System.Diagnostics.Trace.Write($"Creation Result: {creation_result}");

                    if (creation_result)
                        result = APIReference.Instance.FaceListInstance.ListAsync().Result;
                }
                catch
                {
                    throw;
                }
                finally
                {
                    var deletion_result = APIReference.Instance.FaceListInstance.DeleteAsync(identifier).Result;
                    System.Diagnostics.Trace.Write($"Deletion Result: {deletion_result}");
                }

                Assert.True(result != null);
            });
        }

        [Fact]
        public void UpdateAsyncTest()
        {
            TimeoutHelper.ThrowExceptionInTimeout(() =>
            {
                bool result = false;
                var identifier = System.Guid.NewGuid().ToString();

                try
                {
                    var creation_result = APIReference.Instance.FaceListInstance.CreateAsync(identifier, identifier, identifier).Result;
                    System.Diagnostics.Trace.Write($"Creation Result: {creation_result}");

                    if (creation_result)
                        result = APIReference.Instance.FaceListInstance.UpdateAsync(identifier, "Name", "User Data Sample").Result;
                }
                catch
                {
                    throw;
                }
                finally
                {
                    var deletion_result = APIReference.Instance.FaceListInstance.DeleteAsync(identifier).Result;
                    System.Diagnostics.Trace.Write($"Deletion Result: {deletion_result}");
                }

                Assert.True(result);
            });
        }
    }
}