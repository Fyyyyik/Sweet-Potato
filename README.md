# Sweet-Potato

Here is an editor that simplifies KRtDL Mint function in a way so that beginners can start coding some very simple Mint programs.
It is still in beta and lacks a lot of functions and may have bugs so I really need your help to finish this thing, don't be afraid to give feedback to me on Discord @fyyyyik and if you find bugs, please, tell me about it in the "Issues" tab.

For now you can only convert simple functions into Mint code, the functionality to translate Mint code into simpler code will come at a later date. Please be patient.

Here's a list of function included in the "functions.ini" file that comes in the repositery :
  - WaitForAnimEnd() = call GObj.Anim.WaitTillIsAnimEnd()
  - WaitForAnimLoop() = call GObj.Anim.WaitTillIsLooped()
  - WaitForFrame(Frame) =
load r00, 0xX
yield r00
  - WaitForAnimFrame(Frame) =
load r00, 0xA
setArg [00] r00
call GObj.Anim.WaitTillAnimFrame(int)
  - ShakeChara(Frame count) =
load r00, 0xA
setArg [00] r00
call Scn.Step.Chara.Shake.Request(int)
  - ShakeCamera(Frame count) =
load r00, 0xA
setArg [00] r00
call Scn.Step.Camera.CameraController.ReqQuake(int)
  - SpawnLocalEffect(Effect ID,Bone ID) =

call Scn.Step.Hero.Effect.BindState()
load r00, 0xA
load r01, 0xB
setArg [00] r00
setArg [01] r01
call Scn.Step.Chara.Effect.RequestN(int,int)
  - IsAffectedBySlope(true|false) =
setTrue|False r00
setArg [00] r00
call Scn.Step.Chara.SlopeFit.IsValid(bool)
  - SetAttackType(Priority ID,Type) =
load r00, 0xA
load r01, 0xB
setArg [00] r00
setArg [01] r01
call Scn.Step.Chara.ObjColl.SetAttackType(int,int)
  - AddHitbox(Priority ID, Bone ID, Hitbox radius, X Start offset, Y start offset, X end offset, Y end offset
load r00, 0xA
load r01, 0xB
load r02, 0xCCCCCCCC
load r03, 0xDDDDDDDD
load r04, 0xEEEEEEEE
load r05, 0xFFFFFFFF
load r06, 0xGGGGGGGG
setArg [00] r00
setArg [01] r01
setArg [02] r02
setArg [03] r03
setArg [04] r04
setArg [05] r05
setArg [06] r06
call Scn.Step.Chara.ObjColl.AddAttack(int,int,float,float,float,float,float)
