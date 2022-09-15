#include "pch-c.h"
#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include "codegen/il2cpp-codegen-metadata.h"





// 0x00000001 UnityEngine.SocialPlatforms.ISocialPlatform UnityEngine.Social::get_Active()
extern void Social_get_Active_m54586B347AE1248C646891B24054E71C8DE5DC88 (void);
// 0x00000002 System.Void UnityEngine.Social::set_Active(UnityEngine.SocialPlatforms.ISocialPlatform)
extern void Social_set_Active_m3E079BA4CFB75E910F913A8477135C0282BC72FB (void);
// 0x00000003 UnityEngine.SocialPlatforms.ILocalUser UnityEngine.Social::get_localUser()
extern void Social_get_localUser_m7ED6D68F8CBFB7930562BE54601520AEED1D0CE4 (void);
// 0x00000004 UnityEngine.SocialPlatforms.ILocalUser UnityEngine.SocialPlatforms.Local::get_localUser()
extern void Local_get_localUser_m21888B1B23DBA198D651B239D51DBCA525474F9E (void);
// 0x00000005 System.Void UnityEngine.SocialPlatforms.Local::.ctor()
extern void Local__ctor_m223523E0079C7C184D1B804092E5C0A61B0E110E (void);
// 0x00000006 UnityEngine.SocialPlatforms.ISocialPlatform UnityEngine.SocialPlatforms.ActivePlatform::get_Instance()
extern void ActivePlatform_get_Instance_mC9DF8265897D79151D3F86D48A73691B6E3AFA06 (void);
// 0x00000007 System.Void UnityEngine.SocialPlatforms.ActivePlatform::set_Instance(UnityEngine.SocialPlatforms.ISocialPlatform)
extern void ActivePlatform_set_Instance_m11EC15E4BB9909B697B814DAA5C5C8314DE702E9 (void);
// 0x00000008 UnityEngine.SocialPlatforms.ISocialPlatform UnityEngine.SocialPlatforms.ActivePlatform::SelectSocialPlatform()
extern void ActivePlatform_SelectSocialPlatform_mEA0704F85B0FD046DE2E4069B1EC413BD835BCA7 (void);
// 0x00000009 UnityEngine.SocialPlatforms.ILocalUser UnityEngine.SocialPlatforms.ISocialPlatform::get_localUser()
// 0x0000000A System.Boolean UnityEngine.SocialPlatforms.ILocalUser::get_authenticated()
// 0x0000000B System.String UnityEngine.SocialPlatforms.IUserProfile::get_userName()
// 0x0000000C System.String UnityEngine.SocialPlatforms.IUserProfile::get_id()
// 0x0000000D System.Void UnityEngine.SocialPlatforms.Impl.LocalUser::.ctor()
extern void LocalUser__ctor_m6D2AE6DFC61CEC39842944D970E2B2B5547CBE97 (void);
// 0x0000000E System.Boolean UnityEngine.SocialPlatforms.Impl.LocalUser::get_authenticated()
extern void LocalUser_get_authenticated_m3121DA81FF48CFFB4024ADECEE98F8E686497C54 (void);
// 0x0000000F System.Void UnityEngine.SocialPlatforms.Impl.UserProfile::.ctor()
extern void UserProfile__ctor_m12A26F8BDE41F4B55A645BB1D4038E81A877E680 (void);
// 0x00000010 System.String UnityEngine.SocialPlatforms.Impl.UserProfile::ToString()
extern void UserProfile_ToString_mEB091241EC114F4F42D2CE15F127B83556EBE45D (void);
// 0x00000011 System.String UnityEngine.SocialPlatforms.Impl.UserProfile::get_userName()
extern void UserProfile_get_userName_mDAAF12B06B939DDAAB6F10E8CB40B21C48A94F30 (void);
// 0x00000012 System.String UnityEngine.SocialPlatforms.Impl.UserProfile::get_id()
extern void UserProfile_get_id_m16A4060A0C7E4480F68D6915E6FAB15EAE973336 (void);
// 0x00000013 System.Boolean UnityEngine.SocialPlatforms.Impl.UserProfile::get_isFriend()
extern void UserProfile_get_isFriend_m353D113C22BFA80F0E9A1DBEC40E4EF4984AC4EC (void);
// 0x00000014 UnityEngine.SocialPlatforms.UserState UnityEngine.SocialPlatforms.Impl.UserProfile::get_state()
extern void UserProfile_get_state_mF5F8CF4E71CD46ADBCC58E5A3AFA715B3E5F9D4A (void);
static Il2CppMethodPointer s_methodPointers[20] = 
{
	Social_get_Active_m54586B347AE1248C646891B24054E71C8DE5DC88,
	Social_set_Active_m3E079BA4CFB75E910F913A8477135C0282BC72FB,
	Social_get_localUser_m7ED6D68F8CBFB7930562BE54601520AEED1D0CE4,
	Local_get_localUser_m21888B1B23DBA198D651B239D51DBCA525474F9E,
	Local__ctor_m223523E0079C7C184D1B804092E5C0A61B0E110E,
	ActivePlatform_get_Instance_mC9DF8265897D79151D3F86D48A73691B6E3AFA06,
	ActivePlatform_set_Instance_m11EC15E4BB9909B697B814DAA5C5C8314DE702E9,
	ActivePlatform_SelectSocialPlatform_mEA0704F85B0FD046DE2E4069B1EC413BD835BCA7,
	NULL,
	NULL,
	NULL,
	NULL,
	LocalUser__ctor_m6D2AE6DFC61CEC39842944D970E2B2B5547CBE97,
	LocalUser_get_authenticated_m3121DA81FF48CFFB4024ADECEE98F8E686497C54,
	UserProfile__ctor_m12A26F8BDE41F4B55A645BB1D4038E81A877E680,
	UserProfile_ToString_mEB091241EC114F4F42D2CE15F127B83556EBE45D,
	UserProfile_get_userName_mDAAF12B06B939DDAAB6F10E8CB40B21C48A94F30,
	UserProfile_get_id_m16A4060A0C7E4480F68D6915E6FAB15EAE973336,
	UserProfile_get_isFriend_m353D113C22BFA80F0E9A1DBEC40E4EF4984AC4EC,
	UserProfile_get_state_mF5F8CF4E71CD46ADBCC58E5A3AFA715B3E5F9D4A,
};
static const int32_t s_InvokerIndices[20] = 
{
	8689,
	8578,
	8689,
	5711,
	5837,
	8689,
	8578,
	8689,
	0,
	0,
	0,
	0,
	5837,
	5615,
	5837,
	5711,
	5711,
	5711,
	5615,
	5678,
};
IL2CPP_EXTERN_C const Il2CppCodeGenModule g_UnityEngine_GameCenterModule_CodeGenModule;
const Il2CppCodeGenModule g_UnityEngine_GameCenterModule_CodeGenModule = 
{
	"UnityEngine.GameCenterModule.dll",
	20,
	s_methodPointers,
	0,
	NULL,
	s_InvokerIndices,
	0,
	NULL,
	0,
	NULL,
	0,
	NULL,
	NULL,
	NULL, // module initializer,
	NULL,
	NULL,
	NULL,
};
