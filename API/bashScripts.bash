!/bin/bash
 
# echo "wanna chmod?"
# read answer
# yes="y"

# if [ "$answer" = "$yes" ]; then
#     echo "which file to chmod?"
#     read file_name
#     chmod u+x $file_name
#     echo "Done: ${file_name} is excutable."
# fi
# git status
# echo "What is your git Message?"
# sleep 50
# read Message
# git add . 
# git  commit -m "${Message}"
# git push origin master
# echo "DONE: git pushed ${Message} commit."
# git status

# Clear Db
dotnet ef database drop -f -v 
dotnet ef database update 0
dotnet ef migrations remove -f -v
# Add new Migration  
echo "What is your Migration Name?"
read migrate
dotnet ef migrations add $migrate 
# Update Db
dotnet ef database update
