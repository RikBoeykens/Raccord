cd ../../raccord.data.entityframework
dotnet ef --startup-project ../raccord.api migrations add $1
dotnet ef --startup-project ../raccord.api database update
cd ../raccord.api