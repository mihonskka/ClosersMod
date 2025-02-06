using ChronoArkMod.ModData;
using ChronoArkMod.Template;
using ClosersFramework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ClosersFramework.Experiments
{
    [Obsolete]
    public class S_Turquoise_R16_0_Particle// : CustomSkillGDE<ClosersModDefinition>
    {
        /*public override ModGDEInfo.LoadingType GetLoadingType()
        {
            return ModGDEInfo.LoadingType.Replace;
        }

        public override void SetValue()
        {
            Particle = assetInfo.CodeConstuctAsync<GameObject>("Particle/Priest/Priest_CutEffect", ParticleChangeDelegate);
        }
        public override string Key()
        {
            return "C_iseubi0";
        }*/
        public static void SpecialCGRemove(SkillParticle particle)
        {
            particle.SpacialCGMainCharacter.ForEach(g => GameObject.Destroy(g));
            particle.IsSpacialCG = false;
            particle.IsUsingMainCam = false;
            if (!particle.ForceDelayWaitTimealsoNoCG) particle.ForceDelayWaitTime = 0f;
            if (particle.SpacialCGCam != null)
            {
                UnityEngine.Object.Destroy(particle.SpacialCGCam);
                Camera[] componentsInChildren = particle.SpacialCGCam.GetComponentsInChildren<Camera>();
                for (int j = 0; j < componentsInChildren.Length; j++)
                {
                    componentsInChildren[j].enabled = false;
                }
            }
        }
        public void ParticleColorChange(Transform target, Color color)
        {
            if (target == null) { clog.w("PCC的目标传参为空"); }
            ParticleSystem ps = target.GetComponent<ParticleSystem>();
            if(ps==null) { clog.w("PCC取PS为空"); return; }
            try
            {
                var main = ps.main;
                main.startColor = color;
            }
            catch(Exception e)
            { clog.w(e.Message); }
        }
        public GameObject ParticleChangeDelegate(GameObject particle)
        {
            particle.SetActive(false);
            try
            {
                ParticleColorChange(particle.transform, new Color(0, 1, 1, 1));
            }
            catch { clog.w("报错于55行"); }
            try
            {
                ParticleColorChange(particle.transform.GetChild(1), new Color(0, 1, 1, 1));
            }
            catch { clog.w("报错于60行"); }
            try
            {
                ParticleColorChange(particle.transform.GetChild(3), new Color(0, 0.6035668f, 1, 1));
            }
            catch { clog.w("报错于65行"); }
            try
            {
                ParticleColorChange(particle.transform.GetChild(4), new Color(0, 1, 1, 1));
            }
            catch { clog.w("报错于70行"); }
            try
            {
                ParticleColorChange(particle.transform.GetChild(4)?.GetChild(0), new Color(0, 0.9882353f, 1, 1));
            }
            catch { clog.w("报错于75行"); }
            try
            {
                ParticleColorChange(particle.transform.GetChild(4)?.GetChild(0)?.GetChild(0), new Color(0, 0.7058824f, 1, 1));
            }
            catch { clog.w("报错于80行"); }
            try
            {
                ParticleColorChange(particle.transform.GetChild(4)?.GetChild(0)?.GetChild(1), new Color(0, 1, 1, 0.827451f));
            }
            catch { clog.w("报错于85行"); }
            try
            {
                ParticleColorChange(particle.transform.GetChild(4)?.GetChild(0)?.GetChild(2), new Color(0, 0.9204339f, 0.3254902f, 1));
            }
            catch { clog.iw("报错于90行"); }
            try
            {
                ParticleColorChange(particle.transform.GetChild(4)?.GetChild(0)?.GetChild(3), new Color(0, 0.7490196f, 0.9532093f, 1));
            }
            catch { clog.iw("报错于95行"); }
            try
            {
                ParticleColorChange(particle.transform.GetChild(4)?.GetChild(0)?.GetChild(4), new Color(0, 1, 1, 1));
            }
            catch { clog.iw("报错于100行"); }
            try
            {
                ParticleColorChange(particle.transform.GetChild(4)?.GetChild(1), new Color(0, 0, 0.3296418f, 1));
            }
            catch { clog.iw("报错于105行"); }
            try
            {
                ParticleColorChange(particle.transform.GetChild(4)?.GetChild(3), new Color(0, 0.3262867f, 0.4811321f, 1));
            }
            catch { clog.iw("报错于110行"); }
            try
            {
                ParticleColorChange(particle.transform.GetChild(4)?.GetChild(4), new Color(0, 0, 0, 1));
            }
            catch { clog.iw("报错于115行"); }
            try
            {
                ParticleColorChange(particle.transform.GetChild(4)?.GetChild(5), new Color(0, 0, 0, 1));
            }
            catch { clog.iw("报错于120行"); }
            try
            {
                ParticleColorChange(particle.transform.GetChild(4)?.GetChild(6), new Color(0, 0, 0, 1));
            }
            catch { clog.iw("报错于125行"); }
            try
            {
                ParticleColorChange(particle.transform.GetChild(5), new Color(0, 0.9294439f, 1, 1));
            }
            catch { clog.iw("报错于130行"); }
            try
            {
                ParticleColorChange(particle.transform.GetChild(5)?.GetChild(1), new Color(0, 1, 1, 1));
            }
            catch { clog.iw("报错于135行"); }
            try
            {
                ParticleColorChange(particle.transform.GetChild(5)?.GetChild(2), new Color(0, 1, 1, 1));
            }
            catch { clog.iw("报错于140行"); }
            try
            {
                ParticleColorChange(particle.transform.GetChild(5)?.GetChild(2)?.GetChild(0), new Color(0, 0.3262867f, 0.4811321f, 1));
            }
            catch { clog.iw("报错于145行"); }
            try
            {
                ParticleColorChange(particle.transform.GetChild(6), new Color(0, 0.3262867f, 0.4811321f, 1));
            }
            catch { clog.iw("报错于150行"); }
            try
            {
                ParticleColorChange(particle.transform.GetChild(6)?.GetChild(0), new Color(0, 0.3262867f, 0.4811321f, 1));
            }
            catch { clog.iw("报错于155行"); }
            try
            {
                ParticleColorChange(particle.transform.GetChild(6)?.GetChild(2), new Color(0, 0.3262867f, 0.4811321f, 1));
            }
            catch { clog.iw("报错于160行"); }
            try
            {
                ParticleColorChange(particle.transform.GetChild(6)?.GetChild(3), new Color(0, 0.3262867f, 0.4811321f, 1));
            }
            catch { clog.iw("报错于165行"); }
            try
            {
                ParticleColorChange(particle.transform.GetChild(6)?.GetChild(4), new Color(0, 0.3262867f, 0.4811321f, 1));
            }
            catch { clog.iw("报错于170行"); }
            try
            {
                ParticleColorChange(particle.transform.GetChild(6)?.GetChild(5), new Color(0, 0.3262867f, 0.4811321f, 1));
            }
            catch { clog.iw("报错于175行"); }
            try
            {
                ParticleColorChange(particle.transform.GetChild(7), new Color(0, 0.3262867f, 0.4811321f, 1));
            }
            catch { clog.iw("报错于180行"); }
            try
            {
                ParticleColorChange(particle.transform.GetChild(8), new Color(0, 1, 1, 1));
            }
            catch { clog.iw("报错于185行"); }
            try
            {
                ParticleColorChange(particle.transform.GetChild(9), new Color(0, 1, 1, 1));
            }
            catch { clog.iw("报错于190行"); }
            try
            {
                SpecialCGRemove(particle.GetComponent<SkillParticle>());
            }
            catch { clog.iw("报错于195行"); }
            return particle;
        }

        public void myTC(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception e)
            {

            }
        }
    }
}
