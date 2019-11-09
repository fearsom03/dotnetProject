# task_5_Milestone_1
# dotnetProject

Topic : Twitter App

7 Entities: 
User([PK] id , login , pass , [FK]userDataID)
UserData([PK] id , FK[UserForeignKey] foreinKey, name , surname , gender , contry , city)

I hope that you have own eyes and mind to check project and see other properties

Comments 
Group
Tweet
Comment
UserDataGroup

Relationships:
  			//	one to one UserData->User
            //	one to many UserData->Tweets
            //	one to many Tweets -> Comments
            //	one to many UserData->Followers
            //	one to many Group->Tweets
            //	many to many UserData<->Group