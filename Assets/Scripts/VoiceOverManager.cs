using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverManager : MonoBehaviour
{
    public void VoiceOverMainMenu(AudioSource music)
    {

        MainMenuButtons.DisableButtons();

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("INTRO") as AudioClip;

        List<AudioSource> audioSources = new List<AudioSource>();
        audioSources.Add(audioSource);
        StartCoroutine(PlayAudioSource(music, 0.25f, audioSources, 3, "VoiceOverMainMenu"));
    }

    public void VoiceOverHarta(AudioSource music)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("H1") as AudioClip;

        List<AudioSource> audioSources = new List<AudioSource>();
        audioSources.Add(audioSource);
        StartCoroutine(PlayAudioSource(music, 0.25f, audioSources, 0.5f, "VoiceOverHarta"));
    }

    public void VoiceOver_RandomRaspunsCorect()
    {
        int numarFelicitare = Mathf.FloorToInt(Random.Range(1, 7));

        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("C" + numarFelicitare.ToString()) as AudioClip;
        audioSources.Add(audioSource);

        StartCoroutine(PlayAudioSource(music, 0.8f, audioSources, 0, "VoiceOver_RandomRaspunsCorect" + numarFelicitare.ToString()));
    }

    public void VoiceOver_RandomRaspunsGresit()
    {
        int numarFelicitare = Mathf.FloorToInt(Random.Range(1, 8));

        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("G" + numarFelicitare.ToString()) as AudioClip;
        audioSources.Add(audioSource);

        StartCoroutine(PlayAudioSource(music, 0.8f, audioSources, 0, "VoiceOver_RandomRaspunsGresit" + numarFelicitare.ToString()));
    }

    public void VoiceOverTara()
    {
        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("TA1_1") as AudioClip;
        audioSources.Add(audioSource);

        StartCoroutine(PlayAudioSource(music, 0.8f, audioSources, 0, "VoiceOverTara", -0.5f));
    }

    public void VoiceOverTara2()
    {
        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource2.clip = Resources.Load("TA1_2") as AudioClip;
        audioSources.Add(audioSource2);

        AudioSource audioSource3 = gameObject.AddComponent<AudioSource>();
        audioSource3.clip = Resources.Load("TA1_3") as AudioClip;
        audioSources.Add(audioSource3);

        StartCoroutine(PlayAudioSource(music, 0.8f, audioSources, 0, "VoiceOverTara2", -0.5f));
    }

    public void VoiceOverTara_Instructiuni()
    {
        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("TA2_1") as AudioClip;
        audioSources.Add(audioSource);

        StartCoroutine(PlayAudioSource(music, 0.8f, audioSources, 1, "VoiceOverTara_Instructiuni", 1));
    }

    public void VoiceOverTara_Instructiuni2()
    {
        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("TA2_2") as AudioClip;
        audioSources.Add(audioSource);

        StartCoroutine(PlayAudioSource(music, 0.8f, audioSources, 1, "VoiceOverTara_Instructiuni2", 1));
    }

    public void VoiceOverTara_Indiciu(string numarIndiciu)
    {
        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource2.clip = Resources.Load("TA_INDICIU" + numarIndiciu) as AudioClip;
        audioSources.Add(audioSource2);

        StartCoroutine(PlayAudioSource(music, 0.8f, audioSources, 0, "VoiceOverTara_Indiciu" + numarIndiciu));
    }

    public void VoiceOverTara_EndGame()
    {
        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource2.clip = Resources.Load("TA3") as AudioClip;
        audioSources.Add(audioSource2);

        StartCoroutine(PlayAudioSource(music, 0.8f, audioSources, 0.5f, "VoiceOverTara_EndGame", 2));
    }

    public void VoiceOverOras()
    {
        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("OR1_1") as AudioClip;
        audioSources.Add(audioSource);

        StartCoroutine(PlayAudioSource(music, 0.55f, audioSources, 0, "VoiceOverOras", 0.5f));
    }

    public void VoiceOverOras2()
    {
        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource2.clip = Resources.Load("OR1_2") as AudioClip;
        audioSources.Add(audioSource2);

        StartCoroutine(PlayAudioSource(music, 0.55f, audioSources, 0, "VoiceOverOras2", 0.5f));
    }

    public void VoiceOverOras3()
    {
        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource2.clip = Resources.Load("OR1_3") as AudioClip;
        audioSources.Add(audioSource2);

        StartCoroutine(PlayAudioSource(music, 0.55f, audioSources, 0, "VoiceOverOras3", 0.5f));
    }

    public void VoiceOverOras_2_4()
    {
        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource2.clip = Resources.Load("OR2_4") as AudioClip;
        audioSources.Add(audioSource2);

        StartCoroutine(PlayAudioSource(music, 0.55f, audioSources, 0, "VoiceOverOras_2_4", 0.5f));
    }

    public void VoiceOverOras_2_5()
    {
        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource2.clip = Resources.Load("OR2_5") as AudioClip;
        audioSources.Add(audioSource2);

        StartCoroutine(PlayAudioSource(music, 0.55f, audioSources, 0, "VoiceOverOras_2_5", 0.5f));
    }

    public void VoiceOverOras_2_6()
    {
        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource2.clip = Resources.Load("OR2_6") as AudioClip;
        audioSources.Add(audioSource2);

        StartCoroutine(PlayAudioSource(music, 0.55f, audioSources, 0, "VoiceOverOras_2_6", 0.5f));
    }

    public void VoiceOverOras_Indiciu1()
    {
        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource2.clip = Resources.Load("OR_INDICIU1") as AudioClip;
        audioSources.Add(audioSource2);

        StartCoroutine(PlayAudioSource(music, 0.55f, audioSources, 0, "VoiceOverOras_Indiciu1", 0.5f));
    }

    public void VoiceOverOras_Indiciu2()
    {
        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource2.clip = Resources.Load("OR_INDICIU2") as AudioClip;
        audioSources.Add(audioSource2);

        StartCoroutine(PlayAudioSource(music, 0.55f, audioSources, 0, "VoiceOverOras_Indiciu2", 0.5f));
    }

    public void VoiceOverOras_Indiciu3()
    {
        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource2.clip = Resources.Load("OR_INDICIU3") as AudioClip;
        audioSources.Add(audioSource2);

        StartCoroutine(PlayAudioSource(music, 0.55f, audioSources, 0, "VoiceOverOras_Indiciu3", 0.5f));
    }

    public void VoiceOverOras_Instructiuni()
    {
        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("OR2_1") as AudioClip;
        audioSources.Add(audioSource);

        AudioSource audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource2.clip = Resources.Load("OR2_2") as AudioClip;
        audioSources.Add(audioSource2);

        AudioSource audioSource3 = gameObject.AddComponent<AudioSource>();
        audioSource3.clip = Resources.Load("OR2_3") as AudioClip;
        audioSources.Add(audioSource3);

        StartCoroutine(PlayAudioSource(music, 0.55f, audioSources, 0, "VoiceOverOras_Instructiuni", 0.5f));
    }

    public void VoiceOverOras_EndGame()
    {
        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource2.clip = Resources.Load("OR3_1") as AudioClip;
        audioSources.Add(audioSource2);

        StartCoroutine(PlayAudioSource(music, 0.55f, audioSources, 0, "VoiceOverOras_EndGame"));
    }

    public void VoiceOverMare()
    {
        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("MA1_1") as AudioClip;
        audioSources.Add(audioSource);

        AudioSource audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource2.clip = Resources.Load("MA1_2") as AudioClip;
        audioSources.Add(audioSource2);

        StartCoroutine(PlayAudioSource(music, 0.25f, audioSources, 0, "VoiceOverMare", -0.5f));
    }

    public void VoiceOverMare_Instructiuni()
    {
        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("MA2_1") as AudioClip;
        audioSources.Add(audioSource);

        StartCoroutine(PlayAudioSource(music, 0.25f, audioSources, 1, "VoiceOverMare_Instructiuni", 1));
    }

    public void VoiceOverMare_Instructiuni2()
    {
        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource2.clip = Resources.Load("MA2_2") as AudioClip;
        audioSources.Add(audioSource2);

        AudioSource audioSource3 = gameObject.AddComponent<AudioSource>();
        audioSource3.clip = Resources.Load("MA2_3") as AudioClip;
        audioSources.Add(audioSource3);

        StartCoroutine(PlayAudioSource(music, 0.25f, audioSources, 1, "VoiceOverMare_Instructiuni2", 1));
    }

    public void VoiceOverMare_MareValuri()
    {
        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("MA_INDICIU1") as AudioClip;
        audioSources.Add(audioSource);

        StartCoroutine(PlayAudioSource(music, 0.25f, audioSources, 1, "VoiceOverMare_MareValuri", 1));
    }

    public void VoiceOverMare_MelciGata()
    {
        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("MA2_4") as AudioClip;
        audioSources.Add(audioSource);

        StartCoroutine(PlayAudioSource(music, 0.25f, audioSources, 1, "VoiceOverMare_MelciGata", 1));
    }

    public void VoiceOverMare_ScoiciGata()
    {
        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("MA2_6") as AudioClip;
        audioSources.Add(audioSource);

        StartCoroutine(PlayAudioSource(music, 0.25f, audioSources, 1, "VoiceOverMare_ScoiciGata", 1));
    }

    public void VoiceOverMare_PerleGata()
    {
        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("MA2_9") as AudioClip;
        audioSources.Add(audioSource);

        StartCoroutine(PlayAudioSource(music, 0.25f, audioSources, 1, "VoiceOverMare_PerleGata", 1));
    }

    public void VoiceOverMare_CerereMarePerleGata()
    {
        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("MA_INDICIU3") as AudioClip;
        audioSources.Add(audioSource);

        StartCoroutine(PlayAudioSource(music, 0.25f, audioSources, 1, "VoiceOverMare_CerereMarePerleGata", 1));
    }

    public void VoiceOverMare_UltimaSolutieMarea()
    {
        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("MA2_7") as AudioClip;
        audioSources.Add(audioSource);

        StartCoroutine(PlayAudioSource(music, 0.25f, audioSources, 1, "VoiceOverMare_UltimaSolutieMarea", 1));
    }

    public void VoiceOverMare_EndGame()
    {
        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("MA3_1") as AudioClip;
        audioSources.Add(audioSource);

        StartCoroutine(PlayAudioSource(music, 0.25f, audioSources, 1, "VoiceOverMare_EndGame", 1));
    }

    public void VoiceOverMunte()
    {
        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("MU1_1") as AudioClip;
        audioSources.Add(audioSource);

        AudioSource audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource2.clip = Resources.Load("MU1_2") as AudioClip;
        audioSources.Add(audioSource2);

        StartCoroutine(PlayAudioSource(music, 0.25f, audioSources, 0, "VoiceOverMunte", -0.5f));
    }

    public void VoiceOverMunte_Instructiuni()
    {
        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("MU2_1") as AudioClip;
        audioSources.Add(audioSource);

        AudioSource audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource2.clip = Resources.Load("MU2_2") as AudioClip;
        audioSources.Add(audioSource2);

        StartCoroutine(PlayAudioSource(music, 0.25f, audioSources, 1, "VoiceOverMunte_Instructiuni", 1));
    }

    public void VoiceOverMunte_InstructiuniPropozitii()
    {
        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("MU2_3") as AudioClip;
        audioSources.Add(audioSource);

        AudioSource audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource2.clip = Resources.Load("MU2_4") as AudioClip;
        audioSources.Add(audioSource2);

        StartCoroutine(PlayAudioSource(music, 0.25f, audioSources, 1, "VoiceOverMunte_InstructiuniPropozitii", 1));
    }

    public void VoiceOverMunte_EndGame()
    {
        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("MU3_1") as AudioClip;
        audioSources.Add(audioSource);

        AudioSource audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource2.clip = Resources.Load("MU3_2") as AudioClip;
        audioSources.Add(audioSource2);

        StartCoroutine(PlayAudioSource(music, 0.25f, audioSources, 1, "VoiceOverMunte_EndGame", 1));
    }

    public void VoiceOverGame_EndGame()
    {
        GameObject musicObject = GameObject.Find("Music");
        AudioSource music = musicObject.GetComponent<AudioSource>();

        List<AudioSource> audioSources = new List<AudioSource>();

        AudioSource audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource2.clip = Resources.Load("END") as AudioClip;
        audioSources.Add(audioSource2);

        StartCoroutine(PlayAudioSource(music, 0.25f, audioSources, 1, "VoiceOverGame_EndGame", 1));
    }

    IEnumerator PlayAudioSource(AudioSource music, float volumeDiff, List<AudioSource> audioSources, float time, string nume_functie_apelanta, float ajustare = 0f)
    {
        yield return new WaitForSeconds(time);
        music.volume -= volumeDiff;

        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length + ajustare);
        }

        music.volume += volumeDiff;

        if (nume_functie_apelanta == "VoiceOverTara")
        {
            ScriptTara.T1_1_gata = true;
        }
        if (nume_functie_apelanta == "VoiceOverTara2")
        {
            ScriptTara.T1_gata = true;
        }
        if (nume_functie_apelanta == "VoiceOverTara_Instructiuni")
        {
            ScriptTara.T2_gata = true;
        }
        if (nume_functie_apelanta == "VoiceOverTara_Instructiuni2")
        {
            ScriptTara scriptTara = gameObject.GetComponent<ScriptTara>();
            scriptTara.StartGame();
        }
        if (nume_functie_apelanta == "VoiceOverTara_EndGame")
        {
            ScriptTara scriptTara = gameObject.GetComponent<ScriptTara>();
            scriptTara.NextLevel();
        }

        if (nume_functie_apelanta == "VoiceOverOras")
        {
            ScriptOras.OR1_1_gata = true;
        }
        if (nume_functie_apelanta == "VoiceOverOras2")
        {
            ScriptOras.OR1_2_gata = true;
        }
        if (nume_functie_apelanta == "VoiceOverOras3")
        {
            ScriptOras.OR1_3_gata = true;
        }
        if (nume_functie_apelanta == "VoiceOverOras_Instructiuni")
        {
            ScriptOras.OR2_gata = true;
        }
        if (nume_functie_apelanta == "VoiceOverOras_2_4")
        {
            ScriptOras.singleRunIndiciu = true;
        }
        if (nume_functie_apelanta == "VoiceOverOras_2_5")
        {
            ScriptOras.singleRunIndiciu = true;
        }
        if (nume_functie_apelanta == "VoiceOverOras_2_6")
        {
            ScriptOras.singleRunIndiciu = true;
        }
        if (nume_functie_apelanta == "VoiceOverOras_Indiciu1")
        {
            ScriptOras.singleRunIndiciu = true;
        }
        if (nume_functie_apelanta == "VoiceOverOras_Indiciu2")
        {
            ScriptOras.singleRunIndiciu = true;
        }
        if (nume_functie_apelanta == "VoiceOverOras_Indiciu3")
        {
            ScriptOras.singleRunIndiciu = true;
        }
        if (nume_functie_apelanta == "VoiceOverOras_EndGame")
        {
            ScriptOras scriptOras = gameObject.GetComponent<ScriptOras>();
            scriptOras.NextLevel();
        }

        if (nume_functie_apelanta == "VoiceOverMare")
        {
            ScriptMare.MA1_gata = true;
        }
        if (nume_functie_apelanta == "VoiceOverMare_Instructiuni")
        {
            ScriptMare.MA2_gata = true;
        }
        if (nume_functie_apelanta == "VoiceOverMare_Instructiuni2")
        {
            ScriptMare scriptMare = gameObject.GetComponent<ScriptMare>();
            scriptMare.MareCuValuri();
            ScriptMare.MA2_gata2 = true;
            ScriptMare.vorbesteZazi = false;
        }
        if (nume_functie_apelanta == "VoiceOverMare_MareValuri")
        {
            ScriptMare.vorbesteZazi = false;
        }
        if (nume_functie_apelanta == "VoiceOverMare_MelciGata")
        {
            ScriptMare.vorbesteZazi = false;
        }
        if (nume_functie_apelanta == "VoiceOverMare_ScoiciGata")
        {
            ScriptMare.vorbesteZazi = false;
        }
        if (nume_functie_apelanta == "VoiceOverMare_PerleGata")
        {
            ScriptMare.vorbesteZazi = false;
        }
        if (nume_functie_apelanta == "VoiceOverMare_UltimaSolutieMarea")
        {
            ScriptMare.vorbesteZazi = false;
        }
        if (nume_functie_apelanta == "VoiceOverMare_CerereMarePerleGata")
        {
            ScriptMare.vorbesteZazi = false;
        }
        if (nume_functie_apelanta == "VoiceOverMare_EndGame")
        {
            ScriptMare scriptMare = gameObject.GetComponent<ScriptMare>();
            scriptMare.NextLevel();
        }

        if (nume_functie_apelanta == "VoiceOverMainMenu")
        {
            MainMenuButtons.EnableButtons();
        }
        else if (nume_functie_apelanta == "VoiceOverHarta")
        {
            HartaButtons.EnableButtons();
        }

        if (nume_functie_apelanta == "VoiceOverMunte")
        {
            ScriptMunte.MU1_gata = true;
        }
        if (nume_functie_apelanta == "VoiceOverMunte_Instructiuni")
        {
            ScriptMunte.MU2_gata = true;
        }
        if (nume_functie_apelanta == "VoiceOverMunte_InstructiuniPropozitii")
        {
            ScriptMunte.MU2_gata2 = true;
        }
        if (nume_functie_apelanta == "VoiceOverMunte_EndGame")
        {
            ScriptMunte scriptMunte = gameObject.GetComponent<ScriptMunte>();
            scriptMunte.NextLevel();
        }


        if (nume_functie_apelanta == "VoiceOverGame_EndGame")
        {
            GameManager.gataAudioEnd = true;
        }
      
    }
}
