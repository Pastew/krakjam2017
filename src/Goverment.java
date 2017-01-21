import java.util.ArrayList;

/**
 * Created by Sieciech on 2017-01-21.
 */
public class Goverment {

    int attention;
    ArrayList<Spy> spies;

    public Goverment(){
        this.attention = 0;
        spies = new ArrayList<Spy>();

    }

    public void stepGov(){

        this.attention++;
        this.checkSpies();

    }

    public void checkSpies(){

        int i = this.attention;

        if      (i > 0  && i <= 50  && spies.size() < 1) spies.add(new Spy());
        else if (i > 50 && i <= 75  && spies.size() < 2) spies.add(new Spy());
        else if (i > 75 && i <= 90  && spies.size() < 3) spies.add(new Spy());
        else if (i > 90 && i <= 100 && spies.size() < 5) spies.add(new Spy());


        if      (i == 0 &&              spies.size() > 0) spies.clear();
        else if (i > 0  && i <= 50  &&  spies.size() > 1) spies.remove(spies.size() - 1);
        else if (i > 50 && i <= 75  &&  spies.size() > 2) spies.remove(spies.size() - 1);
        else if (i > 75 && i <= 90  &&  spies.size() > 3) {

            if      (spies.size() == 4)     spies.remove(3);
            else if (spies.size() == 5) {   spies.remove(4); spies.remove(3);   }

        }


    }

    public void changeGov(int delta){

        this.attention += delta;
        this.checkSpies();

    }

    public void stepSpies(){

        for(int i = this.spies.size()-1; i >= 0; i--){

            this.spies.get(i).stepSpy();

        }

    }

}
